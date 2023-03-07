using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class CategoryNews : IAuiditEntity
    {
        public int Id { get; set; }
        public int CategoryId  { get; set; }
        public int NewsId { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; } = DateTime.Now;
    }
}
