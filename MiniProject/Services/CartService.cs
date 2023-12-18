using MiniProject.Model;
using MiniProject.Repositories;

namespace MiniProject.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRep repo;
        public CartService(ICartRep repo)
        {
            this.repo = repo;
        }
        public Task<int> AddToCart(Product product)
        {
            return repo.AddToCart(product);
        }
    }
}
