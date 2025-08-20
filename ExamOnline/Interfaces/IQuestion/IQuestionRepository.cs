namespace ExamOnline.Interfaces.IQuestion
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetAllAsync();
        Task<Question?> GetByIdAsync(int id);
        Task<Question?> CreateAsync(Question question);
        Task<Question?> UpdateAsync(Question question);
        Task<bool> DeleteAsync(int id);
        //Task<IEnumerable<Question>> GetQuestionsByExamIdAsync(int examId);
        //Task<IEnumerable<Question>> SearchQuestionsAsync(string searchTerm);
    }
}
