using System.ComponentModel.DataAnnotations;

namespace App.Web.Mvc.Models.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
