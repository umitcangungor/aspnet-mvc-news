using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App.Data.Entities
{
    public class User : IAuiditEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(200),EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez"), Display(Name = "Şifre"), StringLength(100)]    
        public string Password { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez"), Display(Name = "Ad"), StringLength(100)]
        public string Name { get; set; }
        [Display(Name = "Şehir"), StringLength(100)]
        public string? City { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; } = DateTime.Now;
    }
}
