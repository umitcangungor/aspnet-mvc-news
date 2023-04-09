using System.ComponentModel.DataAnnotations;

namespace App.Web.Mvc.Models.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Rol")]
        public string RoleName { get; set; }
    }
}
