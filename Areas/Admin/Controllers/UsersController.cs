using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PIS.Areas.Admin.Models;
using PIS.Models;
using PIS.Services.Contracts;

namespace PIS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAuthService _authService;

        public UsersController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IAuthService authService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _authService = authService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();
            var items = new List<UserListItem>();

            foreach (var user in users)
            {
                var roles = await _authService.GetRolesAsync(user.Id);
                items.Add(new UserListItem
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Roles = roles.Length > 0 ? string.Join(", ", roles) : "-"
                });
            }

            return View(items);
        }

        [HttpGet]
        public IActionResult Create()
        {
            PopulateRoles();
            return View(new UserCreateViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                PopulateRoles();
                return View(model);
            }

            var result = await _authService.CreateUserAsync(model.UserName, model.Password, model.Role);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                PopulateRoles();
                return View(model);
            }

            TempData["success"] = "Kullanıcı oluşturuldu.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var roles = await _authService.GetRolesAsync(user.Id);
            var model = new UserListItem
            {
                Id = user.Id,
                UserName = user.UserName,
                Roles = roles.Length > 0 ? string.Join(", ", roles) : "-"
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var currentUserId = _userManager.GetUserId(User);
            if (string.Equals(currentUserId, id, StringComparison.OrdinalIgnoreCase))
            {
                TempData["error"] = "Kendi hesabınızı silemezsiniz.";
                return RedirectToAction(nameof(Index));
            }

            var ok = await _authService.DeleteUserAsync(id);
            if (!ok)
            {
                return NotFound();
            }

            TempData["success"] = "Kullanıcı silindi.";
            return RedirectToAction(nameof(Index));
        }

        private void PopulateRoles()
        {
            var roles = _roleManager.Roles
                .Select(r => r.Name)
                .Where(r => r != null)
                .OrderBy(r => r)
                .ToList();

            ViewBag.Roles = new SelectList(roles);
        }
    }
}
