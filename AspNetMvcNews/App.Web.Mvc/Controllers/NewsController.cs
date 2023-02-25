using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/news/title-slug")]
        public IActionResult Detail(int id)
        {
            return View();
        }
    }
}
