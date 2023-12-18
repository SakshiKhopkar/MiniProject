using MiniProject.Model;

namespace MiniProject.Services
{
    public interface ICartService
    {
        Task<int> AddToCart(Product product);
    }
}
