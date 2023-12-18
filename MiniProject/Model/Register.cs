using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject.Model
{
    [Table("Users")]
    public class Register
    {
        [Key]
        public int UserId {  get; set; }
      
        public string? UserName { get; set;}
        [Required]
        public string? Password { get; set;}
      
        public string? Email { get; set;}
        [ForeignKey("roleid")]
        public int Roleid {  get; set; }
    }
}
