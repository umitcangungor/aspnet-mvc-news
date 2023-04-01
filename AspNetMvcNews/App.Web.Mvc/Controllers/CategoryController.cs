using App.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ICategoryService _service;

		public CategoryController(ICategoryService service)
		{
			_service = service;
		}
		[Route("/category/category-slug")]
		public async Task<IActionResult> Index(int id)
		{
			var model = await _service.GetCategoryByNews(id);
			return View(model);
		}
	}
}
