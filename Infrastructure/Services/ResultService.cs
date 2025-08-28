using ExamOnline.Dtos;
using ExamOnline.Exceptions;
using ExamOnline.Interfaces.IExam;
using ExamOnline.Interfaces.IResult;
using ExamOnline.Interfaces.IUser;

namespace ExamOnline.Services
{
    public class ResultService : IResultService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ResultService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result?> CreateResultAsync(ResultDTO resultDTO)
        {
            var existingExam = await _unitOfWork.Exams.GetByIdAsync(resultDTO.ExamId);
            if (existingExam == null)
            {
                throw new BadRequestException($"Exam with ID {resultDTO.ExamId} does not exist.");
            }
            var existingUser = await _unitOfWork.Users.GetByIdAsync(resultDTO.UserId);
            if (existingUser == null)
            {
                throw new BadRequestException($"User with ID {resultDTO.UserId} does not exist.");
            }
            var result = _mapper.Map<Result>(resultDTO);
            var createdResult = await _unitOfWork.Results.CreateAsync(result);
            return createdResult;
        }

        public async Task<bool> DeleteResultAsync(int id)
        {
            return await _unitOfWork.Results.DeleteAsync(id);
        }

        public async Task<IEnumerable<Result>> GetAllResultsAsync()
        {
            return await _unitOfWork.Results.GetAllAsync();
        }

        public async Task<Result?> GetResultByIdAsync(int id)
        {
            return await _unitOfWork.Results.GetByIdAsync(id);
        }
        public async Task<Result?> UpdateResultAsync(int id, ResultDTO resultDTO)
        {
            var existingExam = await _unitOfWork.Exams.GetByIdAsync(resultDTO.ExamId);
            if (existingExam == null)
            {
                throw new BadRequestException($"Exam with ID {resultDTO.ExamId} does not exist.");
            }
            var existingUser = await _unitOfWork.Users.GetByIdAsync(resultDTO.UserId);
            if (existingUser == null)
            {
                throw new BadRequestException($"User with ID {resultDTO.UserId} does not exist.");
            }
            var existingResult = await _unitOfWork.Results.GetByIdAsync(id);
            if (existingResult == null)
            {
                return null;
            }
            _mapper.Map(resultDTO, existingResult);
            var updatedResult =  await _unitOfWork.Results.UpdateAsync(existingResult);
            return updatedResult;
        }
    }
}
