namespace Escolar2020.Web.Helpers
{
    using System.Threading.Tasks;
    using Data.Entity;
    using Web.Models;
    using Microsoft.AspNetCore.Identity;
    public interface IUserHelper
	{
        /*Este modulo Implementa la carpeta Models, donde se encuentran las funciones para Usuarios*/
		Task<App_User> GetUserByEmailAsync(string email);
        //Task<App_User> GetUserByUserAsync(string userName);
        Task<IdentityResult> AddUserAsync(App_User user, string password);
        Task<SignInResult> LoginAsync(LoginViewModel model);
        Task LogoutAsync();
        Task<IdentityResult> UpdateUserAsync(App_User user);
        Task<IdentityResult> ChangePasswordAsync(App_User user, string oldPassword, string newPassword);

    }
}
