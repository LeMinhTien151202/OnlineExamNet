using ExamOnline.Dtos;
using ExamOnline.Interfaces.IResult;

namespace ExamOnline.Services
{
    public class ResultService : IResultService
    {
        private readonly IResultRepository _resultRepository;
        private readonly IMapper _mapper;
        public ResultService(IResultRepository resultRepository, IMapper mapper)
        {
            _resultRepository = resultRepository;
            _mapper = mapper;
        }
        public async Task<Result?> CreateResultAsync(ResultDTO resultDTO)
        {
            var result = _mapper.Map<Result>(resultDTO);
            var createdResult = await _resultRepository.CreateAsync(result);
            return createdResult;
        }

        public async Task<bool> DeleteResultAsync(int id)
        {
            return await _resultRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Result>> GetAllResultsAsync()
        {
            return await _resultRepository.GetAllAsync();
        }

        public async Task<Result?> GetResultByIdAsync(int id)
        {
            return await _resultRepository.GetByIdAsync(id);
        }

        public Task<IEnumerable<Result>> GetResultsByCategoryIdAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Result>> GetResultsByExamIdAsync(int examId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Result>> GetResultsByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Result?> UpdateResultAsync(int id, ResultDTO resultDTO)
        {
            var existingResult = await _resultRepository.GetByIdAsync(id);
            if (existingResult == null)
            {
                return null;
            }
            _mapper.Map(resultDTO, existingResult);
            var updatedResult =  await _resultRepository.UpdateAsync(existingResult);
            return updatedResult;
        }
    }
}
