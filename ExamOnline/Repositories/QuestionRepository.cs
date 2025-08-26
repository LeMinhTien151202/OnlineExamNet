
using ExamOnline.Interfaces.IQuestion;
using ExamOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamOnline.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ExamOnlineContext _context;

        public QuestionRepository(ExamOnlineContext context)
        {
            _context = context;

        }
       
    }
}
