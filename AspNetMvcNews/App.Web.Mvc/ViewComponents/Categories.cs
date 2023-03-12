using App.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Web.Mvc.ViewComponents
{
	public class Categories : ViewComponent
    {
        private readonly AppDbContext _db;

        public Categories(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _db.Categories.ToListAsync());
        }

       
    }
}
