using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace App.Web.Mvc.Models.ViewModels
{
	public class RegisterViewModel
	{
		[EmailAddress]
		[Display(Name = "Email")]
		public string Email { get; set; }
		[Required]
		[Display(Name = "Kullanıcı Adı")]
		public string UserName { get; set; }
		[Required]
		[StringLength(100, ErrorMessage = "{0} en az {2} karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Şifre")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Şifre Tekrar")]
		[Compare("Password", ErrorMessage = "Şifreler eşleşmedi!")]
		public string ConfirmPassword { get; set; }

		public string? ReturnUrl { get; set; }
		public IEnumerable<SelectListItem>? RoleList { get; set; }
		[Display(Name = "Seçilen Rol")]
		public string? RoleSelected { get; set; }
	}
}
