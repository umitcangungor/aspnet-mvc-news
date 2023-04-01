using App.Service.Abstract;
using App.Service.Concrete;
using App.Web.Mvc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

		public NewsController(INewsService newsService)
		{
			_newsService = newsService;
		}

		public async Task<IActionResult> Index()
        {
			var model = await _newsService.GetAllAsync(p => p.IsActive);
			return View(model);
		}

        [Route("/news/title-slug")]
        public async Task<IActionResult> Detail(int id)
        {
			var news = await _newsService.GetNewsByCategoriesAsync(id);
			var model = new NewsDetailViewModel()
			{
				News = news,
				NewsList = await _newsService.GetAllAsync(p => p.CategoryId == news.CategoryId && p.Id != id)
			};
			return View(model);
		}
    }
}
