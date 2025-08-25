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

    public ICategoryRepository Categories { get; }
    public ILevelRepository Levels { get; }
    public IExamRepository Exams { get; }
    public IRoleRepository Roles { get; }
    public IQuestionRepository Questions { get; }
    public IResultRepository Results { get; }
    public IUserRepository Users { get; }

    public UnitOfWork(
        ExamOnlineContext context,
        ICategoryRepository categoryRepository,
        ILevelRepository levelRepository,
        IExamRepository examRepository,
        IRoleRepository roleRepository,
        IQuestionRepository questionRepository,
        IResultRepository resultRepository,
        IUserRepository userRepository)
    {
        _context = context;
        Categories = categoryRepository;
        Levels = levelRepository;
        Exams = examRepository;
        Roles = roleRepository;
        Questions = questionRepository;
        Results = resultRepository;
        Users = userRepository;
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