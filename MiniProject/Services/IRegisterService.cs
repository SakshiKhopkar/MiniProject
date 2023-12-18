using MiniProject.Model;

namespace MiniProject.Services
{
    public interface IRegisterService
    {
        Task<int> Registration(Register r);

        Task<Register> GetLogin(Register r);
    }
}
