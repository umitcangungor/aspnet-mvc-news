using System.ComponentModel.DataAnnotations;

namespace App.Data.Entities
{
    public class Contact : IAuiditEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez!"), StringLength(50), Display(Name = "Ad")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez!"), StringLength(50), EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez!"), StringLength(50)]
        [Display(Name = "Konu")]
        public string Subject { get; set; }
        [Display(Name = "Telefon"), StringLength(20)]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez!"), StringLength(500), Display(Name = "Mesaj")]
        public string Message { get; set; }
        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; } = DateTime.Now;
    }
}
