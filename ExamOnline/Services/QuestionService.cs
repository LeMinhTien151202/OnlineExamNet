using ExamOnline.Dtos;
using ExamOnline.Interfaces.IExam;
using ExamOnline.Interfaces.ILevel;
using ExamOnline.Interfaces.IQuestion;
using ExamOnline.Repositories;

namespace ExamOnline.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;
        private readonly IExamRepository _examRepository;
        public QuestionService(IQuestionRepository questionRepository, IMapper mapper, IExamRepository examRepository)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
            _examRepository = examRepository;
        }
        public async Task<Question?> CreateQuestionAsync(QuestionDTO questionDTO)
        {
            var existingExam = await _examRepository.GetByIdAsync(questionDTO.ExamId);
            if (existingExam == null)
            {
                throw new ArgumentException($"Exam with ID {questionDTO.ExamId} does not exist.");
            }
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
        public async Task<Question?> UpdateQuestionAsync(int id, QuestionDTO questionDTO)
        {
            var existingExam = await _examRepository.GetByIdAsync(questionDTO.ExamId);
            if (existingExam == null)
            {
                throw new ArgumentException($"Exam with ID {questionDTO.ExamId} does not exist.");
            }
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
