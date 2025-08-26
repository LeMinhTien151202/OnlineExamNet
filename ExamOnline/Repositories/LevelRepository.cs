
using ExamOnline.Interfaces.ILevel;
using Microsoft.EntityFrameworkCore;

namespace ExamOnline.Repositories
{
    public class LevelRepository : ILevelRepository
    {
        private readonly ExamOnlineContext _context;
        public LevelRepository(ExamOnlineContext context)
        {
            _context = context;

        }
        
        public Task<Level?> GetLevelByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
