using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App.Data.Entities
{
    public class NewsImage 
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        [Display(Name = "Resim Yolu"), StringLength(200)]
        public string ImagePath { get; set; }
    }
}
