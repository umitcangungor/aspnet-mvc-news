using System.ComponentModel.DataAnnotations;

namespace App.Web.Mvc.Models.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmedi!")]
        public string ConfirmPassword { get; set; }
        public string Code { get; set; } // Code email ile iletilecek. Bu istekleri ne zaman yaparsan yap bir token alacaksın ve bu token query string ile iletilecek. Bu da biz modelimize ilettiğimiz zaman o değeri tutacak.
    }
}
