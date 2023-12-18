using MiniProject.Model;
using MiniProject.Repositories;

namespace MiniProject.Services
{
    public class RegisterService:IRegisterService
    {
        private readonly IRegisterRepo repo;
        public RegisterService(IRegisterRepo repo)
        {
            this.repo = repo;
        }

        public async Task<Register> GetLogin(Register r)
        {
            return await repo.GetLogin(r);
        }

        public async Task<int> Registration(Register u)
        {
            return await repo.Registration(u);
        }
    }
}
