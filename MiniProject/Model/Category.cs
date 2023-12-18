using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject.Model
{
    [Table("category")]
    public class Category
    {
        [Key]
        public int Category_id { get; set; }
        public string? Categoryname { get; set; }
    }
}
