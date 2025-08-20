
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
        public async Task<Question?> CreateAsync(Question question)
        {
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null) 
            {
                return false;
            }
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return await _context.Questions.ToListAsync();
        }

        public async Task<Question?> GetByIdAsync(int id)
        {
            return await _context.Questions.FindAsync(id);
        }
        public async Task<Question?> UpdateAsync(Question question)
        {
            _context.Questions.Update(question);
            await _context.SaveChangesAsync();
            return question;
        }
    }
}
