using Microsoft.EntityFrameworkCore;
using MiniProject.Data;
using MiniProject.Model;

namespace MiniProject.Repositories
{
    public class CategoryRepo: ICategoryRepo
    {
        private readonly ApplicationDbContext db;
        public CategoryRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<int> AddCategory(Category category)
        {
            int result = 0;
            await db.Categories.AddAsync(category);
            result = await db.SaveChangesAsync();
            return result;
        }
        public async Task<int> DeleteCategory(int id)
        {
            int result = 0;
            var category = await db.Categories.Where(x => x.Category_id == id).FirstOrDefaultAsync();
            if (category != null)
            {
                db.Categories.Remove(category);
                result = await db.SaveChangesAsync();
            }
            return result;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            var result= await db.Categories.ToListAsync();
            return result;
        }
        public async Task<Category> GetCategoryById(int id)
        {
            var category = await db.Categories.Where(x => x.Category_id == id).FirstOrDefaultAsync();
            return category;
        }
        public async Task<int> UpdateCategory(Category category)
        {
            int result = 0;
            var c = await db.Categories.Where(x => x.Category_id == category.Category_id).FirstOrDefaultAsync();
            if (c != null)
            {

                c.Category_id = category.Category_id;
                c.Categoryname = category.Categoryname;
                result = await db.SaveChangesAsync();
            }
            return result;
        }
    }
}
