using App.Data;
using App.Data.Concrete;
using App.Service.Abstract;

namespace App.Service.Concrete
{
    public class NewsService : NewsRepository, INewsService
    {
        public NewsService(AppDbContext _context) : base(_context)
        {
        }
    }
}
