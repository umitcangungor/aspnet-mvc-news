using App.Data.Entities;
using App.Service.Abstract;
using App.Web.Mvc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class MainController : Controller
	{
		private readonly IService<News> _service;
		private readonly IService<Category> _categoryService;

		public MainController(IService<News> service, IService<Category> categoryService)
		{
			_service = service;
			_categoryService = categoryService;
		}


		public async Task<IActionResult> IndexAsync()
		{
			var model = new HomePageViewModel()
			{
				NewsList = await _service.GetAllAsync(p => p.IsHome),
				Categories = await _categoryService.GetAllAsync(),
			};
			return View(model);
		}
	}
}
