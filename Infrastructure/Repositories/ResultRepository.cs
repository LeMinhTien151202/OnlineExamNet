
using ExamOnline.Interfaces.IResult;
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
    }
}
