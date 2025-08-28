
using ExamOnline.Interfaces.IExam;
using Microsoft.EntityFrameworkCore;

namespace ExamOnline.Repositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly ExamOnlineContext _context;

        public ExamRepository(ExamOnlineContext context)
        {
            _context = context;

        }
       
    }
}
