using MiniProject.Model;
using System.Diagnostics.SymbolStore;

namespace MiniProject.Repositories
{
    public interface IRegisterRepo
    {
        Task<int> Registration(Register r);

        Task<Register> GetLogin(Register r);
    }
}
