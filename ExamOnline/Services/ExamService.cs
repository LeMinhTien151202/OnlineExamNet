using ExamOnline.Dtos;
using ExamOnline.Interfaces.IExam;

namespace ExamOnline.Services
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;
        private readonly IMapper _mapper;
        public ExamService(IMapper mapper, IExamRepository examRepository)
        {
            _mapper = mapper;
            _examRepository = examRepository;
        } 
        public async Task<Exam?> CreateExamAsync(ExamDTO examDTO)
        {
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
            return await _examRepository.GetAllAsync();
        }

        public async Task<Exam?> GetExamByIdAsync(int id)
        {
            return await _examRepository.GetByIdAsync(id);
        }

        public Task<IEnumerable<Exam>> GetExamsByCategoryIdAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Exam>> GetExamsByLevelIdAsync(int levelId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Exam>> SearchExamsAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public async Task<Exam?> UpdateExamAsync(int id, ExamDTO examDTO)
        {
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
