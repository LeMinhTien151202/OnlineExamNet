namespace ExamOnline.Interfaces.IQuestion
{
    public interface IQuestionService
    {
        Task<IEnumerable<Question>> GetAllQuestionsAsync();
        Task<Question?> GetQuestionByIdAsync(int id);
        Task<Question?> CreateQuestionAsync(QuestionDTO questionDTO);
        Task<Question?> UpdateQuestionAsync(int id, QuestionDTO questionDTO);
        Task<bool> DeleteQuestionAsync(int id);
        Task<IEnumerable<Question>> GetQuestionsByExamIdAsync(int examId);
        Task<IEnumerable<Question>> SearchQuestionsAsync(string searchTerm);
    }
}
