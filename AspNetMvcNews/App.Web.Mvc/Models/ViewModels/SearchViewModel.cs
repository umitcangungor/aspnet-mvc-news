using App.Data.Entities;
using X.PagedList;

namespace App.Web.Mvc.Models.ViewModels
{
	public class SearchViewModel
	{
		public IPagedList<News>? NewsList { get; set; }
		public List<Category>? Categories { get; set; }
	}
}
