namespace Escolar2020.Web.Controllers
{
    using System.Threading.Tasks;
    using System.Linq;
    using System.Text;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System;
    using Web.Data.Entity;
    using Web.Helpers;
    using Web.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    
    public class AccountController : Controller
    {
        private readonly IUserHelper userHelper;
        public readonly IConfiguration configuration;

        public AccountController(IUserHelper userHelper,
            IConfiguration configuration)
        {
            this.userHelper = userHelper;
            this.configuration = configuration;
        }
        public IActionResult Login()
        {
            //Validar que no este logueado
            if (this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("Index", "Home");
            }
            return this.View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var result = await this.userHelper.LoginAsync(model);
                if (result.Succeeded)
                {
                    if (this.Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return this.Redirect(this.Request.Query["ReturnUrl"].First());
                    }
                    return this.RedirectToAction("Index", "Home");
                }
            }

            this.ModelState.AddModelError(string.Empty, "Failed to login.");
            return this.View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await this.userHelper.LogoutAsync();
            return this.RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            return this.View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterNewUserViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = await this.userHelper.GetUserByLoginAsync(model.Username);
                if (user == null)
                {
                    user = new App_User
                    {
                        Persona_Id = model.Persona_Id,
                        Clave_Familia = model.Clave_Familia,
                        Rol = model.Rol,
                        Email = model.Email,
                        UserName = model.Username
                    };

                    var result = await this.userHelper.AddUserAsync(user, model.Password);
                    if (result != IdentityResult.Success)
                    {
                        this.ModelState.AddModelError(string.Empty, "The user couldn't be created.");
                        return this.View(model);
                    }
                    var loginViewModel = new LoginViewModel
                    {
                        Password = model.Password,
                        RememberMe = false,
                        Username = model.Username
                    };

                    var result2 = await this.userHelper.LoginAsync(loginViewModel);

                    if (result2.Succeeded)
                    {
                        return this.RedirectToAction("Index", "Home");
                    }

                    this.ModelState.AddModelError(string.Empty, "The user couldn't be login.");
                    return this.View(model);
                }

                this.ModelState.AddModelError(string.Empty, "The username is already registered.");
            }
            return this.View(model);
        }
        public async Task<IActionResult> ChangeUser()
        {
            //todo: Validar que aqui pide el Email y necesito pasar la clave familia.
            var user = await this.userHelper.GetUserByLoginAsync(this.User.Identity.Name);
            var model = new ChangeUserViewModel();
            if (user != null)
            {
                model.Persona_Id = user.Persona_Id;
                model.Clave_Familia = user.Clave_Familia;
            }
            return this.View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeUser(ChangeUserViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = await this.userHelper.GetUserByLoginAsync(this.User.Identity.Name);
                if (user != null)
                {
                    user.Persona_Id = model.Persona_Id;
                    user.Clave_Familia = model.Clave_Familia;
                    var respose = await this.userHelper.UpdateUserAsync(user);
                    if (respose.Succeeded)
                    {
                        this.ViewBag.UserMessage = "User updated!";
                    }
                    else
                    {
                        this.ModelState.AddModelError(string.Empty, respose.Errors.FirstOrDefault().Description);
                    }
                }
                else
                {
                    this.ModelState.AddModelError(string.Empty, "User no found.");
                }
            }
            return this.View(model);
        }
        public IActionResult ChangePassword()
        {
            return this.View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = await this.userHelper.GetUserByLoginAsync(this.User.Identity.Name);
                if (user != null)
                {
                    var result = await this.userHelper.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return this.RedirectToAction("ChangeUser");
                    }
                    else
                    {
                        this.ModelState.AddModelError(string.Empty, result.Errors.FirstOrDefault().Description);
                    }
                }
                else
                {
                    this.ModelState.AddModelError(string.Empty, "User no found.");
                }
            }

            return this.View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateToken([FromBody] LoginViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = await this.userHelper.GetUserByLoginAsync(model.Username);
                if (user != null)
                {
                    var result = await this.userHelper.ValidatePasswordAsync(
                        user,
                        model.Password);
                    if (result.Succeeded)
                    {
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                        };
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["Tokens:Key"]));
                        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            this.configuration["Tokens:Issuer"],
                            this.configuration["Tokens:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddDays(15),
                            signingCredentials: credentials);
                        var results = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo
                        };
                        return this.Created(string.Empty, results);
                    }
                }
            }
            return this.BadRequest();
        }
        public IActionResult NotAuthorized()
        {
            return this.View();
        }

    }
}
