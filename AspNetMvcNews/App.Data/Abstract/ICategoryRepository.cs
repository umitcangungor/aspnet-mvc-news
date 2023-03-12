using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetCategoryByNews(int id);

    }
}
