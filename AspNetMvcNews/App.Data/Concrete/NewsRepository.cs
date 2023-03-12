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
    public class NewsRepository : Repository<News>, INewsRepository
    {
        public NewsRepository(AppDbContext _context) : base(_context)
        {

        }

        public async Task<News> GetNewsByCategoriesAsync(int id)
        {
            return await context.News.Include(c => c.Category).AsNoTracking().FirstOrDefaultAsync(c=>c.Id==id);
        }

      

        public async Task<IEnumerable<News>> GetNewsByCategory()
        {
            return await context.News.Include(c => c.Category).AsNoTracking().ToListAsync();
        }
    }
}
