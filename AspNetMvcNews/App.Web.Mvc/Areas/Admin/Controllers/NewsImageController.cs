using App.Data.Entities;
using App.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class NewsImageController : Controller
    {
        private readonly IService<News> _service;


        public NewsImageController(IService<News> service)
        {
            _service = service;
        }
        // GET: NewsImageController
        public async Task<ActionResult> Index()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        // GET: NewsImageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewsImageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsImageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NewsImageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NewsImageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NewsImageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NewsImageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
