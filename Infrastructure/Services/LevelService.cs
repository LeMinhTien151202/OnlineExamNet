

using ExamOnline.Dtos;
using ExamOnline.Interfaces.ILevel;

namespace ExamOnline.Services
{
    public class LevelService : ILevelService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public LevelService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Level?> CreateLevelAsync(LevelDTO levelDTO)
        {
            var level = _mapper.Map<Level>(levelDTO);
            var createdLevel = await _unitOfWork.Levels.CreateAsync(level);
            return createdLevel;
        }

        public async Task<bool> DeleteLevelAsync(int id)
        {
            var isDeleted = await _unitOfWork.Levels.DeleteAsync(id);
            return isDeleted;
        }

        public async Task<IEnumerable<Level>> GetAllLevelAsync()
        {
            var levels = await _unitOfWork.Levels.GetAllAsync();
            return levels;
        }

        public async Task<Level?> GetLevelByIdAsync(int id)
        {
            var level = await _unitOfWork.Levels.GetByIdAsync(id);
            if (level == null)
            {
                return null;
            }
            return level;
        }

        public Task<IEnumerable<Level>> SearchLevelAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public async Task<Level?> UpdateLevelAsync(int id, LevelDTO levelDTO)
        {
            var existingLevel = await _unitOfWork.Levels.GetByIdAsync(id);
            if (existingLevel == null) 
            {
                return null;
            }
            _mapper.Map(levelDTO, existingLevel);
            var updatedLevel = await _unitOfWork.Levels.UpdateAsync(existingLevel);
            return updatedLevel;

        }
    }
}
