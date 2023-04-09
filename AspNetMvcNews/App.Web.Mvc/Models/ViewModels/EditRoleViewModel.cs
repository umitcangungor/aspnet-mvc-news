using System.ComponentModel.DataAnnotations;

namespace App.Web.Mvc.Models.ViewModels
{
	public class EditRoleViewModel
	{
		public EditRoleViewModel()
		{
			Users = new List<string>();
		}

		public string Id { get; set; }

		[Required(ErrorMessage = "Rol ismi boş geçilemez!")]
		[Display(Name = "Rol Adı")]
		public string RoleName { get; set; }

		public List<string> Users { get; set; }
	}
}
