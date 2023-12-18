using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject.Model
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        public int cartid { get; set; }
        public int productid {  get; set; }
       // public int Userid {  get; set; }

    }
}
