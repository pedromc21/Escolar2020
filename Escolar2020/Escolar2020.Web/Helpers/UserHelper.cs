namespace Escolar2020.Web.Helpers
{
    using System.Threading.Tasks;
    using Data.Entity.Personas;
    using Data.Repositories;
    using Web.Models;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    
    public class UserHelper : IUserHelper
	{
		private readonly UserManager<App_User> userManager;
        private readonly SignInManager<App_User> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ITutorRepository tutorRepository;

        public UserHelper(UserManager<App_User> userManager,
            SignInManager<App_User> signInManager,
            RoleManager<IdentityRole> roleManager,
            ITutorRepository tutorRepository)
		{
			this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.tutorRepository = tutorRepository;
        }
        public IEnumerable<App_User> Users { get; set; }
        //Todo: Obtener Rol del usuario
        public void OnGetAsync()
        {
            this.Users = userManager.Users.Include(u => u.Rol).ToList();
        }
        public async Task<IdentityResult> AddUserAsync(App_User user, string password)
		{
			return await this.userManager.CreateAsync(user, password);
		}
        public async Task AddUserToRoleAsync(App_User user, string rolename)
        {
            await this.userManager.AddToRoleAsync(user, rolename );
        }
        public async Task<IdentityResult> ChangePasswordAsync(App_User user, string oldPassword, string newPassword)
        {
            return await this.userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }
        public async Task CheckRoleAsync(string roleName)
        {
            var roleExists = await this.roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await this.roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }
        public async Task<App_User> GetUserByLoginAsync(string user)
		{
            return await this.userManager.FindByNameAsync(user);  //.FindByEmailAsync(email);
		}
        public async Task<bool> IsUserInRoleAsync(App_User user, string rolename)
        {
            return await this.userManager.IsInRoleAsync(user, rolename);  
        }
        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await this.signInManager.PasswordSignInAsync(
            model.Username,
            model.Password,
            model.RememberMe,
            false);
        }
        public async Task LogoutAsync()
        {
            await this.signInManager.SignOutAsync();
        }
        public async Task<IdentityResult> UpdateUserAsync(App_User user)
        {
            return await this.userManager.UpdateAsync(user);
        }
        public async Task<SignInResult> ValidatePasswordAsync(App_User user, string password)
        {
            return await this.signInManager.CheckPasswordSignInAsync(
                user,
                password,
                false);
        }
        public async Task<string> GetUserNameAsync(int id)
        {
            var app_Tutor = await this.tutorRepository.GetPersonAsync(id);
            return app_Tutor.Nombre;
        }
    }

}
