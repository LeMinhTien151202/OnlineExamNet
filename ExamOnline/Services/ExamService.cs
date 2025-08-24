using ExamOnline.Dtos;
using ExamOnline.Interfaces.ICategory;
using ExamOnline.Interfaces.IExam;
using ExamOnline.Interfaces.ILevel;
using ExceptionHandleDemo.Exceptions;

namespace ExamOnline.Services
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILevelRepository _levelRepository;
        public ExamService(IMapper mapper, IExamRepository examRepository,
            ICategoryRepository categoryRepository, ILevelRepository levelRepository)
        {
            _mapper = mapper;
            _examRepository = examRepository;
            _categoryRepository = categoryRepository;
            _levelRepository = levelRepository;
        } 
        public async Task<Exam?> CreateExamAsync(ExamDTO examDTO)
        {
            var existingCategory = await _categoryRepository.GetByIdAsync(examDTO.CategoryId);
            if (existingCategory == null)
            {
                throw new BadRequestException($"Category with ID {examDTO.CategoryId} does not exist.");
            }
            var existingLevel = await _levelRepository.GetByIdAsync(examDTO.LevelId);
            if (existingLevel == null)
            {
                throw new BadRequestException($"Level with ID {examDTO.LevelId} does not exist.");
            }
            var exam = _mapper.Map<Exam>(examDTO);
            var createdExam = await _examRepository.CreateAsync(exam);
            return createdExam;
        }

        public async Task<bool> DeleteExamAsync(int id)
        {
            return await _examRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Exam>> GetAllExamsAsync()
        {
            var exams = await _examRepository.GetAllAsync();
            return exams;
        }

        public async Task<Exam?> GetExamByIdAsync(int id)
        {
           var exam = await _examRepository.GetByIdAsync(id);
            if (exam == null)
            {
                return null; // Exam not found
            }
            return exam;
        }
        public async Task<Exam?> UpdateExamAsync(int id, ExamDTO examDTO)
        {
            var existingCategory = await _categoryRepository.GetByIdAsync(examDTO.CategoryId);
            if (existingCategory == null)
            {
                throw new BadRequestException($"Category with ID {examDTO.CategoryId} does not exist.");
            }
            var existingLevel = await _levelRepository.GetByIdAsync(examDTO.LevelId);
            if (existingLevel == null)
            {
                throw new BadRequestException($"Level with ID {examDTO.LevelId} does not exist.");
            }
            var existingExam = await _examRepository.GetByIdAsync(id);
            if (existingExam == null)
            {
                return null;
            }
            _mapper.Map(examDTO, existingExam);
            var updatedExam = await _examRepository.UpdateAsync(existingExam);
            return updatedExam;
        }
    }
}
