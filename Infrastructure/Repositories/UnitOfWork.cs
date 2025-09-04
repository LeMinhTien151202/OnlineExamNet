using ExamOnline.Interfaces.ICategory;
using ExamOnline.Interfaces.IExam;
using ExamOnline.Interfaces.ILevel;
using ExamOnline.Interfaces.IQuestion;
using ExamOnline.Interfaces.IResult;
using ExamOnline.Interfaces.IRole;
using ExamOnline.Interfaces.IUser;

public class UnitOfWork : IUnitOfWork
{
    private readonly ExamOnlineContext _context;

    public IGenericRepository<Category> Categories { get; }
    public IGenericRepository<Level> Levels { get; }
    public IGenericRepository<Exam> Exams { get; }
    //public IGenericRepository<Role> Roles { get; }
    public IGenericRepository<Question> Questions { get; }
    public IGenericRepository<Result> Results { get; }
    //public IGenericRepository<User> Users { get; }

    public UnitOfWork(ExamOnlineContext context)
    {
        _context = context;
        Categories = new GenericRepository<Category>(_context);
        Levels = new GenericRepository<Level>(_context);
        Exams = new GenericRepository<Exam>(_context);
        //Roles = new GenericRepository<Role>(_context);
        Questions = new GenericRepository<Question>(_context);
        Results = new GenericRepository<Result>(_context);
        //Users = new GenericRepository<User>(_context);
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}