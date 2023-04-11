using App.Data;
using App.Web.Mvc.Models;
using App.Web.Mvc.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;
using System.Security.Claims;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
	[Area("Admin"), Authorize(Roles = "Admin, Moderator")]
	public class UserController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly RoleManager<AppRole> _roleManager;

		public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _userManager.Users.ToListAsync());
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = new AppUser { Email = model.Email, UserName = model.UserName };

				IdentityResult result = await _userManager.CreateAsync(user, model.Password);

				if (result.Succeeded)
				{
					return RedirectToAction("Index", "User");

				}

				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(error.Code, error.Description);
				}
			}

			return View(model);
		}

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"{id}'li kullanıcı bulunamadı.";
                return NotFound();
            }

            var userClaims = await _userManager.GetClaimsAsync(user);

            var userRoles = await _userManager.GetRolesAsync(user);

            var model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Claims = userClaims.Select(c => c.Value).ToList(),
                Roles = userRoles
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"{model.Id}'li kullanıcı bulunamadı.";
                return NotFound();
            }
            else
            {
                user.Email = model.Email;
                user.UserName = model.UserName;

                var result = await _userManager.UpdateAsync(user);

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
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"{id}'li kullanıcı bulunamadı.";
                return NotFound();
            }
            else
            {
                try
                {
                    var result = await _userManager.DeleteAsync(user);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View("Index");
                }
                catch (Exception)
                {
                    ViewBag.ErrorTitle = $"{user.UserName} kullanıcısı silinememektedir!";
                    ViewBag.ErrorMessage = $"{user.UserName} kullanıcısı bir role sahip olduğu için silinememektedir. Bu kullanıcıyı silmek istiyorsanız, kullanıcının rolünü kaldırın ve sonra tekrar deneyin.";
                    return View("UsersCustomError");
                }
                
            }
        }
        [HttpGet]
        public async Task<IActionResult> ManageClaims(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var existingUserClaims = await _userManager.GetClaimsAsync(user);

            var model = new UserClaimsViewModel()
            {
                UserId = userId
            };

            foreach (Claim claim in ClaimStore.claimList)
            {
                UserClaim userClaim = new UserClaim
                {
                    ClaimType = claim.Type
                };
                if (existingUserClaims.Any(c => c.Type == claim.Type))
                {
                    userClaim.IsSelected = true;
                }
                model.Claims.Add(userClaim);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageClaims(UserClaimsViewModel viewModel)
        {
            var user = await _userManager.FindByIdAsync(viewModel.UserId);
            if (user == null)
            {
                return NotFound();
            }
            var claims = await _userManager.GetClaimsAsync(user);
            var result = await _userManager.RemoveClaimsAsync(user, claims);

            //if (!result.Succeeded)
            //{
            //    return View(viewModel);
            //}

            result = await _userManager.AddClaimsAsync(user, viewModel.Claims.Where(u => u.IsSelected).Select(c => new Claim(c.ClaimType, c.IsSelected.ToString())));

            if (!result.Succeeded)
            {
                return View(viewModel);
            }

            return RedirectToAction("Index");
        }
    }
}
