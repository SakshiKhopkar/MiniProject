using Microsoft.EntityFrameworkCore;
using MiniProject.Model;
using System.Collections.Generic;

namespace MiniProject.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> op) : base(op)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Register> registers { get; set; }
        public DbSet<Cart> carts{ get; set; }
    }
}
