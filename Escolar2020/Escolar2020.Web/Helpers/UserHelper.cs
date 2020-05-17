namespace Escolar2020.Web.Helpers
{
    using System.Threading.Tasks;
    using Data.Entity;
    using Escolar2020.Web.Models;
    using Microsoft.AspNetCore.Identity;

    public class UserHelper : IUserHelper
	{
		private readonly UserManager<App_User> userManager;
        private readonly SignInManager<App_User> signInManager;

        public UserHelper(UserManager<App_User> userManager,
            SignInManager<App_User> signInManager)
		{
			this.userManager = userManager;
            this.signInManager = signInManager;
        }

		public async Task<IdentityResult> AddUserAsync(App_User user, string password)
		{
			return await this.userManager.CreateAsync(user, password);
		}

        public async Task<IdentityResult> ChangePasswordAsync(App_User user, string oldPassword, string newPassword)
        {
            return await this.userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }

        public async Task<App_User> GetUserByEmailAsync(string email)
		{
			return await this.userManager.FindByEmailAsync(email);
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
    }

}
