using App.Data.Entities;
using App.Service.Abstract;
using App.Service.Concrete;
using App.Web.Mvc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace App.Web.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IService<Category> _categoryService;
        private readonly INewsService _newsService;
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service, INewsService newsService, IService<Category> categoryService)
        {
            _service = service;
            _newsService = newsService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index(int id, int? page)
        {
            int pageSize = 4;
            int pageIndex = 1;

            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;


            var model = new HomePageViewModel()
            {
                PagedNews = await _newsService.GetAllNewsByCategoryToPagedList(id, pageIndex, pageSize),
                NewsList = await _newsService.GetAllAsync(),
                Category = await _service.GetCategoryByNews(id),
                Categories = await _categoryService.GetAllAsync(),
            };

            return View(model);
        }
    }
}
