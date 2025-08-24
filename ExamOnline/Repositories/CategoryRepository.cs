

using ExamOnline.Interfaces.ICategory;
using ExamOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamOnline.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ExamOnlineContext _context;

        public CategoryRepository(ExamOnlineContext context)
        {
            _context = context;
            
        }
        public async Task<Category?> CreateAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task<bool> DeleteAsync(int id)
        {
           var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return false;
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
           return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<Category?> UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
