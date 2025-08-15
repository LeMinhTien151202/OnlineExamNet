
namespace ExamOnline.Interfaces
{
    public interface IExamRepository
    {
        Task<IEnumerable<ExamDTO>> GetAllExamsAsync();
        Task<ExamDTO?> GetExamByIdAsync(int id);
        Task<ExamDTO?> CreateExamAsync(ExamDTO examDTO);
        Task<ExamDTO?> UpdateExamAsync(ExamDTO examDTO);
        Task<bool> DeleteExamAsync(int id);
        Task<IEnumerable<ExamDTO>> GetExamsByCategoryIdAsync(int categoryId);
        Task<IEnumerable<ExamDTO>> GetExamsByLevelIdAsync(int levelId);
        Task<IEnumerable<ExamDTO>> GetExamsByUserIdAsync(int userId);
    }
}
