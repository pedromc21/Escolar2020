namespace Escolar2020.Web.Helpers
{
	using System.Threading.Tasks;
	using Data.Entity;
	using Microsoft.AspNetCore.Identity;
	public interface IUserHelper
	{
		Task<App_User> GetUserByEmailAsync(string email);

		Task<IdentityResult> AddUserAsync(App_User user, string password);
    }

}
