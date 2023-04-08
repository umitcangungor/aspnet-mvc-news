using App.Data.Abstract;
using App.Data.Entities;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace App.Data.Concrete
{
    public class NewsRepository : Repository<News>, INewsRepository
    {
        public NewsRepository(AppDbContext _context) : base(_context)
        {
        }

        public async Task<IEnumerable<News>> GetAllNewsByCategoriesAsync()
        {
            return await context.News.Include(c => c.Category).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<News>> GetAllNewsByCategoriesToPagedList()
        {
            return await context.News.Include(c => c.Category).OrderByDescending(x => x.Id).AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<News>> GetAllNewsByCategoryToPagedList(int categoryId, int pageIndex, int pageSize)
        {
            return await context.News.Where(n => n.CategoryId == categoryId).Include(n => n.Category).OrderByDescending(n => n.CreatedAt).ToPagedListAsync(pageIndex, pageSize);
        }

        public async Task<News> GetNewsByCategoriesAsync(int id)
        {
            return await context.News.Include(c => c.Category).AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
