
namespace ExamOnline.Repositories
{
    public class LevelRepository : ILevelRepository
    {
        public Task<LevelDTO?> CreateLevelAsync(LevelDTO levelDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteLevelAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LevelDTO>> GetAllLevelsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<LevelDTO?> GetLevelByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<LevelDTO?> GetLevelByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<LevelDTO?> UpdateLevelAsync(LevelDTO levelDTO)
        {
            throw new NotImplementedException();
        }
    }
}
