using Microsoft.EntityFrameworkCore;
using MiniProject.Data;
using MiniProject.Model;

namespace MiniProject.Repositories
{
    public class RegisterRepo:IRegisterRepo
    {
        private readonly ApplicationDbContext db;

        public RegisterRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<Register> GetLogin(Register r)
        {
            
            var result = db.registers.Where(x=>x.Email == r.Email && x.Password== r.Password).FirstOrDefault();
            return result;
        }



        public async Task<int> Registration(Register r)
        {
            r.Roleid = 2;
            db.registers.Add(r);
            int result = await db.SaveChangesAsync();
            return result;
        }
    }
}
