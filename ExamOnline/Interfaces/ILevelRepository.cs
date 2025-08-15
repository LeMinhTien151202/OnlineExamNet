namespace ExamOnline.Interfaces
{
    public interface ILevelRepository
    {
        Task<IEnumerable<LevelDTO>> GetAllLevelsAsync();
        Task<LevelDTO?> GetLevelByIdAsync(int id);
        Task<LevelDTO?> CreateLevelAsync(LevelDTO levelDTO);
        Task<LevelDTO?> UpdateLevelAsync(LevelDTO levelDTO);
        Task<bool> DeleteLevelAsync(int id);
        Task<LevelDTO?> GetLevelByNameAsync(string name);
    }
}
