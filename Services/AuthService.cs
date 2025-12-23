using Microsoft.AspNetCore.Identity;
using PIS.Models;
using PIS.Services.Contracts;

namespace PIS.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> PasswordSignInAsync(string userName, string password, bool rememberMe)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, rememberMe, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public Task SignOutAsync()
        {
            return _signInManager.SignOutAsync();
        }

        public async Task<(bool Succeeded, string[] Errors)> CreateUserAsync(string userName, string password, string role)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                return (false, new[] { "Belirtilen rol bulunamadı." });
            }

            var user = new ApplicationUser
            {
                UserName = userName,
                Email = userName
            };

            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                return (false, result.Errors.Select(e => e.Description).ToArray());
            }

            await _userManager.AddToRoleAsync(user, role);
            return (true, Array.Empty<string>());
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<string[]> GetRolesAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return Array.Empty<string>();
            }

            var roles = await _userManager.GetRolesAsync(user);
            return roles.ToArray();
        }

        public async Task<bool> IsInRoleAsync(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            return await _userManager.IsInRoleAsync(user, role);
        }
    }
}
