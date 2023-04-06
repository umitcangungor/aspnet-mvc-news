using System.ComponentModel.DataAnnotations;

namespace App.Data.Entities
{

    public class Category : IAuiditEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez!"), StringLength(50), Display(Name = "Kategori Adı")]
        public string Name { get; set; }
        [Display(Name = "Kategori Açıklaması")]
        public string? Description { get; set; }
        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
        [Display(Name = "Üst Menüde Göster")]
        public bool IsTopMenu { get; set; }
        [Display(Name = "Üst Kategori")]
        public int ParentId { get; set; }
        [Display(Name = "Kategori Sıra No")]
        public int OrderNo { get; set; }
        [Display(Name = "Haberler")]
        public virtual ICollection<News>? News { get; set; }
		[Display(Name = "Oluşturulma Tarihi")]
		public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;    
        public DateTime? DeletedAt { get; set; } = DateTime.Now;
    }
}
