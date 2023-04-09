using App.Data.Entities;
using App.Service.Abstract;
using App.Service.Concrete;
using App.Web.Mvc.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Admin, Moderator")]
    public class NewsCommentController : Controller
    {
        private readonly IService<NewsComment> _comment;

        public NewsCommentController(IService<NewsComment> comment)
        {
            _comment = comment;
        }

        public IActionResult Index()
        {
            var list = _comment.GetAll();
            return View(list);
        }
        // GET: NewsCommentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsCommentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewsComment newsComment)
        {
            try
            {
                _comment.Add(newsComment);
                _comment.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: ContactsController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _comment.Find(id);
            return View(model);
        }

        // POST: NewsCommentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NewsComment newsComment)
        {
            try
            {
                _comment.Update(newsComment);
                _comment.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: NewsCommentController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _comment.Find(id);
            return View(model);
        }

        // POST: NewsCommentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, NewsComment newsComment)
        {
            try
            {
                _comment.Delete(newsComment);
                _comment.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
