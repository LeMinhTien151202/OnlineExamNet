
using ExamOnline.Interfaces.ILevel;
using ExamOnline.Models;
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
        public async Task<Level?> CreateAsync(Level level)
        {
            await _context.AddAsync(level);
            await _context.SaveChangesAsync();
            return level;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var level = await _context.Levels.FindAsync(id);
            if (level == null)
            {
                return false;
            }
            _context.Levels.Remove(level);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Level>> GetAllAsync()
        {
            return await _context.Levels.ToListAsync();
        }

        public async Task<Level?> GetByIdAsync(int id)
        {
            return await _context.Levels.FindAsync(id);
        }

        public Task<Level?> GetLevelByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Level?> UpdateAsync(Level level)
        {
            _context.Levels.Update(level);
            await _context.SaveChangesAsync();
            return level;
        }
    }
}
