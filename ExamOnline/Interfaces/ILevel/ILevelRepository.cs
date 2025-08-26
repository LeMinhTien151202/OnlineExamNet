namespace ExamOnline.Interfaces.ILevel
{
    public interface ILevelRepository
    {
        Task<Level?> GetLevelByNameAsync(string name);
    }
}
