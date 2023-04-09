using App.Data;
using App.Web.Mvc.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Admin, Moderator")]
    public class RoleController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _roleManager.Roles.ToListAsync());
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _roleManager.CreateAsync(new AppRole { Name = model.RoleName });

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

		[HttpGet]
		public async Task<IActionResult> EditRole(string id)
		{
			var role = await _roleManager.FindByIdAsync(id);

			if (role == null)
			{
				ViewBag.ErrorMessage = $"{id}'li rol bulunamadı!";
				return NotFound();
			}

			var model = new EditRoleViewModel
			{
				Id = role.Id,
				RoleName = role.Name
			};

			foreach (var user in _userManager.Users.ToList()) // ToList() eklemeyince Data Reader Exception fırlatıyor!!!!
			{
				if (await _userManager.IsInRoleAsync(user, role.Name))
				{
					model.Users.Add(user.UserName);
				}
			}

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> EditRole(EditRoleViewModel model)
		{
			var role = await _roleManager.FindByIdAsync(model.Id);

			if (role == null)
			{
				ViewBag.ErrorMessage = $"{model.Id}'li rol bulunamadı!";
				return NotFound();
			}
			else
			{
				role.Name = model.RoleName;

				var result = await _roleManager.UpdateAsync(role);

				if (result.Succeeded)
				{
					return RedirectToAction("Index");
				}

				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}

				return View(model);
			}
		}

		[HttpGet]
		public async Task<IActionResult> EditUsersInRole(string roleId)
		{
			ViewBag.roleId = roleId;

			var role = await _roleManager.FindByIdAsync(roleId);

			if (role == null)
			{
				ViewBag.ErrorMessage = $"{roleId}'li rol bulunamadı!";
				return NotFound();
			}

			var model = new List<UserRoleViewModel>();

			foreach (var user in _userManager.Users.ToList())
			{
				var userRoleViewModel = new UserRoleViewModel
				{
					UserId = user.Id,
					UserName = user.UserName
				};

				if (await _userManager.IsInRoleAsync(user, role.Name))
				{
					userRoleViewModel.IsSelected = true;
				}
				else
				{
					userRoleViewModel.IsSelected = false;
				}

				model.Add(userRoleViewModel);
			}

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId)
		{
			var role = await _roleManager.FindByIdAsync(roleId);

			if (role == null)
			{
				ViewBag.ErrorMessage = $"{roleId}'li rol bulunamadı!";
				return NotFound();
			}

			for (int i = 0; i < model.Count; i++)
			{
				var user = await _userManager.FindByIdAsync(model[i].UserId);

				IdentityResult result = null;

				if (model[i].IsSelected && !await _userManager.IsInRoleAsync(user, role.Name))
				{
					result = await _userManager.AddToRoleAsync(user, role.Name);
				}
				else if (!model[i].IsSelected && await _userManager.IsInRoleAsync(user, role.Name))
				{
					result = await _userManager.RemoveFromRoleAsync(user, role.Name);
				}
				else
				{
					continue;
				}

				if (result.Succeeded)
				{
					if (i < (model.Count - 1))
						continue;
					else
						return RedirectToAction("EditRole", new { Id = roleId });
				}
			}

			return RedirectToAction("EditRole", new { Id = roleId });
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"{id}'li rol bulunamadı!";
                return NotFound();
            }
            else
            {
                try
                {
                    //throw new Exception("Test Exception");

                    var result = await _roleManager.DeleteAsync(role);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }

                    return View("Index");
                }

                catch (DbUpdateException) // DbUpdateException database'e bir şey kaydederken ortaya çıkan sorunları yakalayıp hata fırlatıyor.
                {
                    ViewBag.ErrorTitle = $"{role.Name} rolü kullanımdadır.";
                    ViewBag.ErrorMessage = $"{role.Name} rolünde kullanıcılar bulunduğu için silinememektedir. Bu rolü silmek istiyorsanız, bu roldeki kullanıcıları kaldırın ve ondan sonra tekrar deneyin.";
                    return View("CustomError");
                }
            }
        }

    }
}
