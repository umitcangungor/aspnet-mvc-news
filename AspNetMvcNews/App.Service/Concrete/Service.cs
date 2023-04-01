using App.Data;
using App.Data.Concrete;
using App.Data.Entities;
using App.Service.Abstract;

namespace App.Service.Concrete
{
    public class Service<T> : Repository<T>, IService<T> where T : class, IAuiditEntity, new()
    {
        public Service(AppDbContext _context) : base(_context)
        {
        }
    }
}
