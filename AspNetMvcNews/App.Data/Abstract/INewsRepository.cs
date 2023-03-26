using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Abstract
{
    public interface INewsRepository : IRepository<News>
    {
        Task<IEnumerable<News>> GetAllNewsByCategoriesAsync();
        Task<News> GetNewsByCategoriesAsync(int id);

    }
}
