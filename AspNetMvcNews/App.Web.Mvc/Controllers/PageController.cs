using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class PageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/page/title-slug")]
        public IActionResult Detail(int id)
        {
            return View();
        }
    }
}
