

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
        
    }
}
