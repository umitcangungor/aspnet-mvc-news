using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class Slider : IAuiditEntity
    {
        public int Id { get; set; }

        [Display(Name = "Başlık"), StringLength(150)]
        public string? Title { get; set; }

        [Display(Name = "Açıklama"), StringLength(500)]
        public string? Description { get; set; }

        [Display(Name = "Resim"), StringLength(150)]
        public string? Image { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }


    }
}
