using ExamOnline.Dtos;
using ExamOnline.Interfaces.IExam;
using ExamOnline.Interfaces.IResult;
using ExamOnline.Interfaces.IUser;
using ExceptionHandleDemo.Exceptions;

namespace ExamOnline.Services
{
    public class ResultService : IResultService
    {
        private readonly IResultRepository _resultRepository;
        private readonly IMapper _mapper;
        private readonly IExamRepository _examRepository;
        private readonly IUserRepository _userRepository;
        public ResultService(IResultRepository resultRepository, IMapper mapper,
            IExamRepository examRepository, IUserRepository userRepository)
        {
            _resultRepository = resultRepository;
            _mapper = mapper;
            _examRepository = examRepository;
            _userRepository = userRepository;
        }
        public async Task<Result?> CreateResultAsync(ResultDTO resultDTO)
        {
            var existingExam = await _examRepository.GetByIdAsync(resultDTO.ExamId);
            if (existingExam == null)
            {
                throw new BadRequestException($"Exam with ID {resultDTO.ExamId} does not exist.");
            }
            var existingUser = await _userRepository.GetByIdAsync(resultDTO.UserId);
            if (existingUser == null)
            {
                throw new BadRequestException($"User with ID {resultDTO.UserId} does not exist.");
            }
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
        public async Task<Result?> UpdateResultAsync(int id, ResultDTO resultDTO)
        {
            var existingExam = await _examRepository.GetByIdAsync(resultDTO.ExamId);
            if (existingExam == null)
            {
                throw new BadRequestException($"Exam with ID {resultDTO.ExamId} does not exist.");
            }
            var existingUser = await _userRepository.GetByIdAsync(resultDTO.UserId);
            if (existingUser == null)
            {
                throw new BadRequestException($"User with ID {resultDTO.UserId} does not exist.");
            }
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
