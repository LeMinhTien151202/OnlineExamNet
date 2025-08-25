using ExamOnline.Interfaces.ICategory;
using ExamOnline.Interfaces.IExam;
using ExamOnline.Interfaces.ILevel;
using ExamOnline.Interfaces.IQuestion;
using ExamOnline.Interfaces.IResult;
using ExamOnline.Interfaces.IRole;
using ExamOnline.Interfaces.IUser;

public interface IUnitOfWork : IDisposable
{
    ICategoryRepository Categories { get; }
    ILevelRepository Levels { get; }
    IExamRepository Exams { get; }
    IRoleRepository Roles { get; }
    IQuestionRepository Questions { get; }
    IResultRepository Results { get; }
    IUserRepository Users { get; }
    Task<int> SaveAsync();
}