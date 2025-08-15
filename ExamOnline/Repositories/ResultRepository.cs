

namespace ExamOnline.Repositories
{
    public class ResultRepository : IResultRepository
    {
        public Task<ResultDTO?> CreateResultAsync(ResultDTO resultDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteResultAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ResultDTO>> GetAllResultsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResultDTO?> GetResultByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ResultDTO>> GetResultsByCategoryIdAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ResultDTO>> GetResultsByExamIdAsync(int examId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ResultDTO>> GetResultsByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<ResultDTO?> UpdateResultAsync(ResultDTO resultDTO)
        {
            throw new NotImplementedException();
        }
    }
}
