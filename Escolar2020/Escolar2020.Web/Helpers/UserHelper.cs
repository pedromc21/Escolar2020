namespace Escolar2020.Web.Helpers
{
	using System.Threading.Tasks;
	using Data.Entity;
	using Microsoft.AspNetCore.Identity;

	public class UserHelper : IUserHelper
	{
		private readonly UserManager<App_User> userManager;

		public UserHelper(UserManager<App_User> userManager)
		{
			this.userManager = userManager;
		}

		public async Task<IdentityResult> AddUserAsync(App_User user, string password)
		{
			return await this.userManager.CreateAsync(user, password);
		}

		public async Task<App_User> GetUserByEmailAsync(string email)
		{
			return await this.userManager.FindByEmailAsync(email);
		}
	}

}
