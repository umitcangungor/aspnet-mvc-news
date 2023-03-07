using System.ComponentModel.DataAnnotations;

namespace App.Data.Entities
{
    public class News : IAuiditEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [Display(Name = "Haber Başlığı"), StringLength(200)]
        public string Title { get; set; }
        [Display(Name = "Haber İçeriği")]
        public string Content { get; set; }


        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; } = DateTime.Now;



    }
}
