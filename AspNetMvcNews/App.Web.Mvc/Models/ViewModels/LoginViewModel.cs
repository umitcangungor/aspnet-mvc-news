using System.ComponentModel.DataAnnotations;

namespace App.Web.Mvc.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
