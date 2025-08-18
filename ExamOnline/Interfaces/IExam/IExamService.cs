namespace ExamOnline.Interfaces.IExam
{
    public interface IExamService
    {
        Task<IEnumerable<Exam>> GetAllAsync();
        Task<Exam?> GetByIdAsync(int id);
        Task<Exam?> CreateAsync(ExamDTO examDTO);
        Task<Exam?> UpdateAsync(ExamDTO examDTO);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Exam>> GetExamsByCategoryIdAsync(int categoryId);
        Task<IEnumerable<Exam>> GetExamsByLevelIdAsync(int levelId);
        Task<IEnumerable<Exam>> SearchExamsAsync(string searchTerm);
    }
}
