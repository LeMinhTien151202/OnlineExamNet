namespace ExamOnline.Interfaces.IResult
{
    public interface IResultService
    {
        Task<IEnumerable<Result>> GetAllResultsAsync();
        Task<Result?> GetResultByIdAsync(int id);
        Task<Result?> CreateResultAsync(ResultDTO resultDTO);
        Task<Result?> UpdateResultAsync(int id, ResultDTO resultDTO);
        Task<bool> DeleteResultAsync(int id);
        Task<IEnumerable<Result>> GetResultsByExamIdAsync(int examId);
        Task<IEnumerable<Result>> GetResultsByUserIdAsync(int userId);
        Task<IEnumerable<Result>> GetResultsByCategoryIdAsync(int categoryId);
    }
}
