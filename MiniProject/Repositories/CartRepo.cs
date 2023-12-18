using MiniProject.Data;
using MiniProject.Model;

namespace MiniProject.Repositories
{
    public class CartRepo : ICartRep
    {
        private readonly ApplicationDbContext db;
        public CartRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<int> AddToCart(Product product)
        {
            Cart cart = new Cart();
            cart.productid = product.Id;
            int result = 0;
            await db.carts.AddAsync(cart);
            result = await db.SaveChangesAsync();
            return result;

        }
    }
}
