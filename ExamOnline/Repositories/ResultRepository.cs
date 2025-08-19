

using ExamOnline.Interfaces.IResult;
using ExamOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamOnline.Repositories
{
    public class ResultRepository : IResultRepository
    {
        private readonly ExamOnlineContext _context;

        public ResultRepository(ExamOnlineContext context)
        {
            _context = context;

        }
        public async Task<Result?> CreateAsync(Result result)
        {
            await _context.Results.AddAsync(result);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _context.Results.FindAsync(id);
            if (result == null) 
            {
                return false;
            }
            _context.Results.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Result>> GetAllAsync()
        {
            return await _context.Results.ToListAsync();
        }

        public async Task<Result?> GetByIdAsync(int id)
        {
            return await _context.Results.FindAsync(id);
        }

        public Task<IEnumerable<Result>> GetResultsByCategoryIdAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Result>> GetResultsByExamIdAsync(int examId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Result>> GetResultsByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Result?> UpdateAsync(Result result)
        {
            _context.Results.Update(result);
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
