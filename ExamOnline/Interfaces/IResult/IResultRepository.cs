namespace ExamOnline.Interfaces.IResult
{
    public interface IResultRepository
    {
        Task<IEnumerable<Result>> GetResultsByExamIdAsync(int examId);
        Task<IEnumerable<Result>> GetResultsByUserIdAsync(int userId);
        Task<IEnumerable<Result>> GetResultsByCategoryIdAsync(int categoryId);
    }
}
