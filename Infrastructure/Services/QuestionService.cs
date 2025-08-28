using ExamOnline.Dtos;
using ExamOnline.Exceptions;
using ExamOnline.Interfaces.IExam;
using ExamOnline.Interfaces.ILevel;
using ExamOnline.Interfaces.IQuestion;
using ExamOnline.Repositories;

namespace ExamOnline.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public QuestionService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Question?> CreateQuestionAsync(QuestionDTO questionDTO)
        {
            var existingExam = await _unitOfWork.Exams.GetByIdAsync(questionDTO.ExamId);
            if (existingExam == null)
            {
                throw new BadRequestException($"Exam with ID {questionDTO.ExamId} does not exist.");
            }
            var question = _mapper.Map<Question>(questionDTO);
            var createdQuestion = await _unitOfWork.Questions.CreateAsync(question);
            return createdQuestion;
        }

        public async Task<bool> DeleteQuestionAsync(int id)
        {
            return await _unitOfWork.Questions.DeleteAsync(id);
        }

        public async Task<IEnumerable<Question>> GetAllQuestionsAsync()
        {
            return await _unitOfWork.Questions.GetAllAsync();
        }

        public Task<Question?> GetQuestionByIdAsync(int id)
        {
            return _unitOfWork.Questions.GetByIdAsync(id);
        }
        public async Task<Question?> UpdateQuestionAsync(int id, QuestionDTO questionDTO)
        {
            var existingExam = await _unitOfWork.Exams.GetByIdAsync(questionDTO.ExamId);
            if (existingExam == null)
            {
                throw new BadRequestException($"Exam with ID {questionDTO.ExamId} does not exist.");
            }
            var existingQuestin = await _unitOfWork.Questions.GetByIdAsync(id);
            if (existingQuestin == null)
            {
                return null;
            }
            _mapper.Map(questionDTO, existingQuestin);
            var updatedQuestion = await _unitOfWork.Questions.UpdateAsync(existingQuestin);
            return updatedQuestion;
        }
    }
}
