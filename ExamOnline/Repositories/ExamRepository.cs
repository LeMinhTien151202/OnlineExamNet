


namespace ExamOnline.Repositories
{
    public class ExamRepository : IExamRepository
    {
        public Task<ExamDTO?> CreateExamAsync(ExamDTO examDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteExamAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ExamDTO>> GetAllExamsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ExamDTO?> GetExamByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ExamDTO>> GetExamsByCategoryIdAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ExamDTO>> GetExamsByLevelIdAsync(int levelId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ExamDTO>> GetExamsByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<ExamDTO?> UpdateExamAsync(ExamDTO examDTO)
        {
            throw new NotImplementedException();
        }
    }
}
