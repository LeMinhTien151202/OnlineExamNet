namespace ExamOnline.Interfaces.IExam
{
    public interface IExamService
    {
        Task<IEnumerable<Exam>> GetAllExamsAsync();
        Task<Exam?> GetExamByIdAsync(int id);
        Task<Exam?> CreateExamAsync(ExamDTO examDTO);
        Task<Exam?> UpdateExamAsync(int id, ExamDTO examDTO);
        Task<bool> DeleteExamAsync(int id);
        Task<IEnumerable<Exam>> GetExamsByCategoryIdAsync(int categoryId);
        Task<IEnumerable<Exam>> GetExamsByLevelIdAsync(int levelId);
        Task<IEnumerable<Exam>> SearchExamsAsync(string searchTerm);
    }
}
