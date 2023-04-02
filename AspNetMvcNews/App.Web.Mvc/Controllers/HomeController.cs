using App.Data.Entities;
using App.Service.Abstract;
using App.Web.Mvc.Models;
using App.Web.Mvc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IService<News> _service;
        private readonly IService<Category> _categoryService;

        public HomeController(ILogger<HomeController> logger, IService<News> service, IService<Category> categoryService)
        {
            _logger = logger;
            _service = service;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var model = new HomePageViewModel()
            {
                NewsList = await _service.GetAllAsync(p => p.IsHome),
                Categories = await _categoryService.GetAllAsync()
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}