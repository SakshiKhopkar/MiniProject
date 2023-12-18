using MiniProject.Model;

namespace MiniProject.Repositories
{
    public interface ICartRep
    {
        Task<int> AddToCart(Product product);
    }
}
