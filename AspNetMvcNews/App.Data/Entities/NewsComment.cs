using System.ComponentModel.DataAnnotations;

namespace App.Data.Entities
{
    public class NewsComment : IAuiditEntity
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        [Display(Name = "Yorum")]
        public string Comment { get; set; }
        public bool IsActive { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; } = DateTime.Now;
    }
}
