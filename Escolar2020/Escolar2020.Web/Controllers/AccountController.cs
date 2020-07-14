namespace Escolar2020.Web.Controllers
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using Web.Data.Entity.Personas;
    using Web.Helpers;
    using Web.Models;

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
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await userHelper.LoginAsync(model);
                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Error al iniciar sesión.");
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await userHelper.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterNewUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userHelper.GetUserByLoginAsync(model.Username);
                if (user == null)
                {
                    user = new App_User
                    {
                        Persona_Id = model.Persona_Id,
                        Clave_Familia = model.Clave_Familia,
                        Email = model.Email,
                        UserName = model.Username
                    };

                    var result = await userHelper.AddUserAsync(user, model.Password);
                    if (result != IdentityResult.Success)
                    {
                        ModelState.AddModelError(string.Empty, "El usuario no pudo ser creado.");
                        return View(model);
                    }
                    var loginViewModel = new LoginViewModel
                    {
                        Password = model.Password,
                        RememberMe = false,
                        Username = model.Username
                    };

                    var result2 = await userHelper.LoginAsync(loginViewModel);

                    if (result2.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    ModelState.AddModelError(string.Empty, "El usuario no pudo iniciar sesión.");
                    return View(model);
                }

                ModelState.AddModelError(string.Empty, "El nombre de usuario ya está registrado.");
            }
            return View(model);
        }
        public async Task<IActionResult> ChangeUser()
        {
            var user = await userHelper.GetUserByLoginAsync(User.Identity.Name);
            string NamePerson = userHelper.GetUserNameAsync(user.Persona_Id).Result;
            var model = new ChangeUserViewModel();
            if (user != null)
            {
                model.Persona_Id = user.Persona_Id;
                model.Clave_Familia = user.Clave_Familia;
                model.Usuario = user.UserName;
                model.NombreUsuario = NamePerson;
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeUser(ChangeUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userHelper.GetUserByLoginAsync(User.Identity.Name);
                if (user != null)
                {
                    user.Persona_Id = model.Persona_Id;
                    user.Clave_Familia = model.Clave_Familia;
                    var respose = await userHelper.UpdateUserAsync(user);
                    if (respose.Succeeded)
                    {
                        ViewBag.UserMessage = "Usuario actualizado!";
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, respose.Errors.FirstOrDefault().Description);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Usuario no encontrado.");
                }
            }
            return View(model);
        }
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userHelper.GetUserByLoginAsync(User.Identity.Name);
                if (user != null)
                {
                    var result = await userHelper.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("ChangeUser");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, result.Errors.FirstOrDefault().Description);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Usuario no encontrado.");
                }
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateToken([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userHelper.GetUserByLoginAsync(model.Username);
                if (user != null)
                {
                    var result = await userHelper.ValidatePasswordAsync(
                        user,
                        model.Password);
                    if (result.Succeeded)
                    {
                        var claims = new[]
                        {
                            //Email
                            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                        };
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));
                        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            configuration["Tokens:Issuer"],
                            configuration["Tokens:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddDays(15),
                            signingCredentials: credentials);
                        var results = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo
                        };
                        return Created(string.Empty, results);
                    }
                }
            }
            return BadRequest();
        }
        public IActionResult NotAuthorized()
        {
            return View();
        }

    }
}
