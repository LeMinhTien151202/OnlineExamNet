namespace ExamOnline.Interfaces.ILevel
{
    public interface ILevelService
    {
        Task<IEnumerable<Level>> GetAllLevelAsync();
        Task<Level?> GetLevelByIdAsync(int id);
        Task<Level?> CreateLevelAsync(LevelDTO levelDTO);
        Task<Level?> UpdateLevelAsync(int id, LevelDTO levelDTO);
        Task<bool> DeleteLevelAsync(int id);
        Task<IEnumerable<Level>> SearchLevelAsync(string searchTerm);
    }
}
