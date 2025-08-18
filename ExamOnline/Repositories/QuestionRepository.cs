
using ExamOnline.Interfaces.IQuestion;

namespace ExamOnline.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        public Task<QuestionDTO?> CreateQuestionAsync(QuestionDTO questionDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteQuestionAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<QuestionDTO>> GetAllQuestionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<QuestionDTO?> GetQuestionByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<QuestionDTO>> GetQuestionsByExamIdAsync(int examId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<QuestionDTO>> SearchQuestionsAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public Task<QuestionDTO?> UpdateQuestionAsync(QuestionDTO questionDTO)
        {
            throw new NotImplementedException();
        }
    }
}
