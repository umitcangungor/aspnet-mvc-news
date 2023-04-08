using App.Data.Entities;
using X.PagedList;

namespace App.Data.Abstract
{
	public interface INewsRepository : IRepository<News>
	{
		Task<IEnumerable<News>> GetAllNewsByCategoriesAsync();
		Task<IEnumerable<News>> GetAllNewsByCategoriesToPagedList();
		Task<IPagedList<News>> GetAllNewsByCategoryToPagedList(int categoryId, int pageIndex, int pageSize);
		Task<News> GetNewsByCategoriesAsync(int id);

	}
}
