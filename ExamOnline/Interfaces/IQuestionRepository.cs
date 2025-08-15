namespace ExamOnline.Interfaces
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<QuestionDTO>> GetAllQuestionsAsync();
        Task<QuestionDTO?> GetQuestionByIdAsync(int id);
        Task<QuestionDTO?> CreateQuestionAsync(QuestionDTO questionDTO);
        Task<QuestionDTO?> UpdateQuestionAsync(QuestionDTO questionDTO);
        Task<bool> DeleteQuestionAsync(int id);
        Task<IEnumerable<QuestionDTO>> GetQuestionsByExamIdAsync(int examId);
        Task<IEnumerable<QuestionDTO>> SearchQuestionsAsync(string searchTerm);
    }
}
