namespace ExamOnline.Interfaces
{
    public interface IResultRepository
    {
        Task<IEnumerable<ResultDTO>> GetAllResultsAsync();
        Task<ResultDTO?> GetResultByIdAsync(int id);
        Task<ResultDTO?> CreateResultAsync(ResultDTO resultDTO);
        Task<ResultDTO?> UpdateResultAsync(ResultDTO resultDTO);
        Task<bool> DeleteResultAsync(int id);
        Task<IEnumerable<ResultDTO>> GetResultsByExamIdAsync(int examId);
        Task<IEnumerable<ResultDTO>> GetResultsByUserIdAsync(int userId);
        Task<IEnumerable<ResultDTO>> GetResultsByCategoryIdAsync(int categoryId);
    }
}
