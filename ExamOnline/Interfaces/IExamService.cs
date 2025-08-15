namespace ExamOnline.Interfaces
{
    public interface IExamService
    {
        Task<IEnumerable<Exam>> GetAllExamsAsync();
        Task<Exam?> GetExamByIdAsync(int id);
        Task<Exam?> CreateExamAsync(Exam exam);
        Task<Exam?> UpdateExamAsync(Exam exam);
        Task<bool> DeleteExamAsync(int id);
        Task<IEnumerable<Exam>> GetExamsByCategoryIdAsync(int categoryId);
        Task<IEnumerable<Exam>> GetExamsByLevelIdAsync(int levelId);
        Task<IEnumerable<Exam>> SearchExamsAsync(string searchTerm);
    }
}
