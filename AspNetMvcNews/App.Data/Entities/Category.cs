using System.ComponentModel.DataAnnotations;

namespace App.Data.Entities
{

    public class Category : IAuiditEntity
    {
        public int Id { get; set; }
        [Display(Name="Kategori Adı"),StringLength(100)]
        public string Name { get; set; }
        [Display(Name = "Kategori Açıklaması"), StringLength(200)]
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;    
        public DateTime? DeletedAt { get; set; } = DateTime.Now;

        [Display(Name ="Haberler")]    
        public virtual ICollection<News>? News { get; set; }
    }
}
