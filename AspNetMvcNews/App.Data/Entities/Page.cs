    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class Page : IAuiditEntity
    {
        public int Id { get; set; }
        [Display(Name ="Sayfa Başlığı"),StringLength(200)]
        public string Title { get; set; }
        [Display(Name = "Sayfa İçeriği")]
        public string Content { get; set; }
        public bool IsActive { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; } = DateTime.Now;

    }
}
