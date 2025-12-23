using System.Threading.Tasks;

namespace PIS.Services.Contracts
{
    public interface IAuthService
    {
        Task<bool> PasswordSignInAsync(string userName, string password, bool rememberMe);
        Task SignOutAsync();
        Task<(bool Succeeded, string[] Errors)> CreateUserAsync(string userName, string password, string role);
        Task<bool> DeleteUserAsync(string userId);
        Task<string[]> GetRolesAsync(string userId);
        Task<bool> IsInRoleAsync(string userId, string role);
    }
}
