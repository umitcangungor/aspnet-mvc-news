using App.Data.Entities;
using App.Service.Abstract;
using App.Web.Mvc.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing.Drawing2D;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : Controller
    {
        private readonly IService<News> _service;
        private readonly IService<Category> _serviceCategory;
        private readonly INewsService _newsService;

        public NewsController(IService<News> service, IService<Category> serviceCategory, INewsService newsService)
        {
            _service = service;
            _serviceCategory = serviceCategory;
            _newsService = newsService;
        }

        // GET: NewsController

        public async Task<ActionResult> Index()
        {
            var model = await _newsService.GetAllNewsByCategoriesAsync();
            return View(model);
        }

        // GET: NewsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewsController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await _serviceCategory.GetAllAsync(), "Id", "Name");
            
            return View();
        }


        // POST: NewsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(News news, IFormFile? ImagePath)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (ImagePath is not null) news.ImagePath = await FileHelper.FileLoaderAsync(ImagePath);
                    await _service.AddAsync(news);
                    await _service.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.CategoryId = new SelectList(await _serviceCategory.GetAllAsync(), "Id", "Name");
            return View(news);
        }

        // GET: NewsController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var model = await _service.FindAsync(id);
            ViewBag.CategoryId = new SelectList(await _serviceCategory.GetAllAsync(), "Id", "Name");
            return View(model);
        }

        // POST: NewsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(News news, int id, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Image is not null) news.ImagePath = await FileHelper.FileLoaderAsync(Image, filePath: "/wwwroot/img/NewsImage/");
                    _service.Update(news);
                    await _service.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.CategoryId = new SelectList(await _serviceCategory.GetAllAsync(), "Id", "Name");
            return View(news);
        }

        // GET: NewsController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: NewsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(News news, int id)
        {
            try
            {
                FileHelper.FileRemover(news.ImagePath, filePath: "/wwwroot/img/NewsImage/");
                _service.Delete(news);
                _service.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
