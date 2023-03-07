using System.ComponentModel.DataAnnotations;

namespace App.Data.Entities
{
    public class Setting
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ StringLength(200)]
        public string Name { get; set; }
        [ StringLength(400)]
        public string Value { get; set; }
    }
}
