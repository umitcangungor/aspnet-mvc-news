using App.Data.Entities;
using X.PagedList;

namespace App.Web.Mvc.Models.ViewModels
{
	public class HomePageViewModel
    {
        public List<News>? NewsList { get; set; }
        public IPagedList<News>? PagedNews { get; set; }
		public News News { get; set; }
		public List<Category>? Categories { get; set; }
		public Category Category { get; set; }
    }
}
