using App.Data.Entities;
using App.Service.Abstract;
using App.Service.Concrete;
using App.Web.Mvc.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsCommentController : Controller
    {
        private readonly IService<NewsComment> _comment;

        public NewsCommentController(IService<NewsComment> comment)
        {
            _comment = comment;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _comment.GetAllAsync();
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewsComment comment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _comment.AddAsync(comment);
                    await _comment.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(comment);
        }
    }
}
