using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
	public class CategoryController : Controller
	{
		[Route("/category/category-slug")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
