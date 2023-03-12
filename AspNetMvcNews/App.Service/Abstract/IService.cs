using App.Data.Abstract;
using App.Data.Entities;

namespace App.Service.Abstract
{
    public interface IService<T> : IRepository<T> where T : class, IAuiditEntity, new()
    {

         

    }
}
