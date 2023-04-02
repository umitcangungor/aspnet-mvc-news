using App.Data.Entities;

namespace App.Data.Abstract
{
	public interface INewsRepository : IRepository<News>
	{
		Task<IEnumerable<News>> GetAllNewsByCategoriesAsync();
		Task<News> GetNewsByCategoriesAsync(int id);
		Task<News> GetLastNewsAsync(int id);

    }
}
