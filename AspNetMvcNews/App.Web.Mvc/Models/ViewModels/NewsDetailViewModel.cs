using App.Data.Entities;

namespace App.Web.Mvc.Models.ViewModels
{
	public class NewsDetailViewModel
	{
		public News News { get; set; }
		public List<News>? NewsList { get; set; }
	}
}
