using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiniProject.Model
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]

        public int? Price { get; set; }
        [Required]
        public string? ImageUrl { get; set; }
        [Required]
        [ForeignKey("Cid")]
        public int Category_id { get; set; }
        [NotMapped]
        public string? Category_name { get; set; }
        public int Stock {  get; set; }
    }
}
