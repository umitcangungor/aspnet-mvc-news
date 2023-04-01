using App.Data.Entities;
using App.Service.Abstract;
using App.Web.Mvc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
	public class NewsController : Controller
    {
		private readonly INewsService _service;

		public NewsController(INewsService service)
		{
			_service = service;
		}

		public async Task<IActionResult> Index()
        {
			var model = await _service.GetAllNewsByCategoriesAsync(); // ?????
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
