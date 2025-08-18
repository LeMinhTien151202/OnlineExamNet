namespace ExamOnline.Interfaces.IResult
{
    public interface IResultRepository
    {
        Task<IEnumerable<Result>> GetAllAsync();
        Task<Result?> GetByIdAsync(int id);
        Task<Result?> CreateAsync(Result result);
        Task<Result?> UpdateAsync(Result result);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Result>> GetResultsByExamIdAsync(int examId);
        Task<IEnumerable<Result>> GetResultsByUserIdAsync(int userId);
        Task<IEnumerable<Result>> GetResultsByCategoryIdAsync(int categoryId);
    }
}
