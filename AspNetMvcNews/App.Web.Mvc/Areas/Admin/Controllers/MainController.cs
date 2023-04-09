using App.Data;
using App.Data.Entities;
using App.Service.Abstract;
using App.Web.Mvc.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
	[Area("Admin"), Authorize(Roles = "Admin, Moderator")]
	public class MainController : Controller
	{
		private readonly IService<News> _service;
		private readonly IService<Category> _categoryService;
		private readonly SignInManager<AppUser> _signInManager;

		public MainController(IService<News> service, IService<Category> categoryService, SignInManager<AppUser> signInManager)
		{
			_service = service;
			_categoryService = categoryService;
			_signInManager = signInManager;
		}


		public async Task<IActionResult> Index()
		{
			var model = new HomePageViewModel()
			{
				NewsList = await _service.GetAllAsync(p => p.IsHome),
				Categories = await _categoryService.GetAllAsync(),
			};
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> LogOut()
		{
			await _signInManager.SignOutAsync();
			return Redirect("~/");
		}
	}
}
