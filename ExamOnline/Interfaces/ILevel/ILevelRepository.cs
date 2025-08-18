namespace ExamOnline.Interfaces.ILevel
{
    public interface ILevelRepository
    {
        Task<IEnumerable<Level>> GetAllAsync();
        Task<Level?> GetByIdAsync(int id);
        Task<Level?> CreateAsync(Level level);
        Task<Level?> UpdateAsync(Level level);
        Task<bool> DeleteAsync(int id);
        Task<Level?> GetLevelByNameAsync(string name);
    }
}
