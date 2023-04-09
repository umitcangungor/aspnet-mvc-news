using App.Data.Entities;
using App.Service.Abstract;
using App.Web.Mvc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

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

		public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 4;
            int pageIndex = 1;

            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

			var newsList = await _service.GetAllNewsByCategoriesToPagedList();

            IPagedList<News> newsPagedList = new PagedList<News>(newsList, pageIndex, pageSize);

            return View(newsPagedList);
		}

		public async Task<IActionResult> Search(string q, int? page)
		{
            int pageSize = 4;
            int pageIndex = 1;

            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            var newsList = await _service.GetAllNewsByCategoriesToPagedList();
            var filteredNewsList = newsList.Where(p => p.IsActive && p.Title.ToUpper().Contains(q.ToUpper()));
            IPagedList<News> newsPagedList = new PagedList<News>(filteredNewsList, pageIndex, pageSize);


            q = q.Trim();
			//var news = await _service.GetAllAsync(p => p.IsActive && p.Title.ToUpper().Contains(q.ToUpper()));
			var model = new SearchViewModel()
			{
				NewsList = newsPagedList,
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
