

using ExamOnline.Dtos;
using ExamOnline.Interfaces.ILevel;

namespace ExamOnline.Services
{
    public class LevelService : ILevelService
    {
        private readonly ILevelRepository _levelRepository;
        private readonly IMapper _mapper;
        public LevelService(ILevelRepository levelRepository, IMapper mapper)
        {
            _levelRepository = levelRepository;
            _mapper = mapper;
        }

        public Task<Level?> CreateLevelAsync(LevelDTO levelDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteLevelAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Level>> GetAllLevelAsync()
        {
            var levels = await _levelRepository.GetAllAsync();
            return levels;
        }

        public async Task<Level?> GetLevelByIdAsync(int id)
        {
            var level = await _levelRepository.GetByIdAsync(id);
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
            var existingLevel = await _levelRepository.GetByIdAsync(id);
            if (existingLevel == null) 
            {
                return null;
            }
            _mapper.Map(levelDTO, existingLevel);
            var updatedLevel = await _levelRepository.UpdateAsync(existingLevel);
            return updatedLevel;

        }
    }
}
