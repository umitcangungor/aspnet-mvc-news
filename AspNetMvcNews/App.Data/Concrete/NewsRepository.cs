using App.Data.Abstract;
using App.Data.Entities;
using Microsoft.EntityFrameworkCore;

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

		public async Task<News> GetNewsByCategoriesAsync(int id)
		{
			return await context.News.Include(c => c.Category).AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
		}
	}
}
