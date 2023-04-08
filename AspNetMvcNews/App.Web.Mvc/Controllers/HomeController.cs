using App.Data.Entities;
using App.Service.Abstract;
using App.Web.Mvc.Models;
using App.Web.Mvc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml;

namespace App.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IService<News> _service;
        private readonly IService<Category> _categoryService;
        private readonly IService<Contact> _serviceContact;

        public HomeController(ILogger<HomeController> logger, IService<News> service, IService<Category> categoryService, IService<Contact> serviceContact)
        {
            _logger = logger;
            _service = service;
            _categoryService = categoryService;
            _serviceContact = serviceContact;
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
		public IActionResult AboutUs()
        {
            return View();
        }

		[Route("Iletisim")]
        public IActionResult ContactUs()
        {
            return View();
        }
        [Route("Iletisim"), HttpPost]
        public async Task<IActionResult> ContactUs(Contact contact)
        {
            try
            {
                await _serviceContact.AddAsync(contact);
                await _serviceContact.SaveChangesAsync();
                TempData["Mesaj"] = "<div class = 'alert alert-success'>Mesajınız Gönderildi. Teşekkürler...</div>";
                return RedirectToAction("ContactUs");
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Hata Oluştu! Mesajınız Gönderilemedi!");
            }

            return View();
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