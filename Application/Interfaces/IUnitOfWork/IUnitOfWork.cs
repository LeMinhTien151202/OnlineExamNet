using ExamOnline.Interfaces.ICategory;
using ExamOnline.Interfaces.IExam;
using ExamOnline.Interfaces.ILevel;
using ExamOnline.Interfaces.IQuestion;
using ExamOnline.Interfaces.IResult;
using ExamOnline.Interfaces.IRole;
using ExamOnline.Interfaces.IUser;

public interface IUnitOfWork : IDisposable
{
    public IGenericRepository<Category> Categories { get; }
    public IGenericRepository<Level> Levels { get; }
    public IGenericRepository<Exam> Exams { get; }
    //public IGenericRepository<Role> Roles { get; }
    public IGenericRepository<Question> Questions { get; }
    public IGenericRepository<Result> Results { get; }
    //public IGenericRepository<User> Users { get; }

    Task<int> SaveAsync();
}