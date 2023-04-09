using System.ComponentModel.DataAnnotations;

namespace App.Data.Entities
{
    public class News : IAuiditEntity
    {
		public int Id { get; set; }
		[Required(ErrorMessage = "{0} alanı boş geçilemez!"), StringLength(100), Display(Name = "Haber Başlığı")]
		public string Title { get; set; }
		[Display(Name = "Haber Açıklaması")]
		public string? Content { get; set; }
		[Display(Name = "Resim Yolu"), StringLength(200)]
		public string? ImagePath { get; set; }
		[Display(Name = "Durum")]
		public bool IsActive { get; set; }
		[Display(Name = "Anasayfa")]
		public bool IsHome { get; set; }
		[Display(Name = "Kategori")]
		public int CategoryId { get; set; }
		[Display(Name = "Kategori")]
		public Category? Category { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; } = DateTime.Now;



    }
}
