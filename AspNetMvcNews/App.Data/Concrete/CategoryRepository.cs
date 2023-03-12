using App.Data.Abstract;
using App.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Concrete
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext _context) : base(_context)
        {
        }
    
        public async Task<Category> GetCategoryByNews(int id)
        {
            return await context.Categories.Where(k => k.Id == id).AsNoTracking().Include(p => p.News).FirstOrDefaultAsync();
        }
    }
}
