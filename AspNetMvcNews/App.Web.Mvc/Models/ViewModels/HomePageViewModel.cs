using App.Data.Entities;

namespace App.Web.Mvc.Models.ViewModels
{
	public class HomePageViewModel
    {
        public List<News>? NewsList { get; set; }
		public News News { get; set; }
		public List<Category>? Categories { get; set; }
		public Category Category { get; set; }
    }
}
