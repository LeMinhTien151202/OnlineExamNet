using ExamOnline.Dtos;
using ExamOnline.Interfaces.ILevel;
using ExamOnline.Interfaces.IQuestion;
using ExamOnline.Repositories;

namespace ExamOnline.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;
        public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }
        public async Task<Question?> CreateQuestionAsync(QuestionDTO questionDTO)
        {
            var question = _mapper.Map<Question>(questionDTO);
            var createdQuestion = await _questionRepository.CreateAsync(question);
            return createdQuestion;
        }

        public async Task<bool> DeleteQuestionAsync(int id)
        {
            return await _questionRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Question>> GetAllQuestionsAsync()
        {
            return await _questionRepository.GetAllAsync();
        }

        public Task<Question?> GetQuestionByIdAsync(int id)
        {
            return _questionRepository.GetByIdAsync(id);
        }

        public Task<IEnumerable<Question>> GetQuestionsByExamIdAsync(int examId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Question>> SearchQuestionsAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public async Task<Question?> UpdateQuestionAsync(int id, QuestionDTO questionDTO)
        {
            var existingQuestin = await _questionRepository.GetByIdAsync(id);
            if (existingQuestin == null)
            {
                return null;
            }
            _mapper.Map(questionDTO, existingQuestin);
            var updatedQuestion = await _questionRepository.UpdateAsync(existingQuestin);
            return updatedQuestion;
        }
    }
}
