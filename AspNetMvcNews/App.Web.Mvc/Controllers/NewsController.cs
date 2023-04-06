using App.Data.Entities;
using App.Service.Abstract;
using App.Web.Mvc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
	public class NewsController : Controller
    {
		private readonly IService<Category> _categoryService;
		private readonly INewsService _service;

		public NewsController(INewsService service, IService<Category> categoryService)
		{
			_service = service;
			_categoryService = categoryService;
		}

		public async Task<IActionResult> Index()
        {
			var model = await _service.GetAllNewsByCategoriesAsync();
			return View(model);
		}

		public async Task<IActionResult> Search(string q)
		{
			q = q.Trim();
			var news = await _service.GetAllAsync(p => p.IsActive && p.Title.ToUpper().Contains(q.ToUpper()));
			var model = new SearchViewModel()
			{
				NewsList = news,
				Categories = await _categoryService.GetAllAsync(),
			};
			return View(model);
		}


		[Route("/news/title-slug")]
        public async Task<IActionResult> Detail(int id)
        {
			var news = await _service.GetNewsByCategoriesAsync(id);
			var model = new NewsDetailViewModel()
			{
				News = news,
				NewsList = await _service.GetAllAsync(p => p.CategoryId == news.CategoryId && p.Id != id)
			};
			return View(model);
		}
    }
}
