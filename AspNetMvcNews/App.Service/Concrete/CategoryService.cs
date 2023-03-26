using App.Data;
using App.Data.Concrete;
using App.Service.Abstract;

namespace App.Service.Concrete
{
    public class CategoryService : CategoryRepository, ICategoryService
    {
        public CategoryService(AppDbContext _context) : base(_context)
        {
        }
    }
}
