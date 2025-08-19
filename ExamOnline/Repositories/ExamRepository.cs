


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
        public async Task<Exam?> CreateAsync(Exam exam)
        {
            await _context.Exams.AddAsync(exam);
            await _context.SaveChangesAsync();
            return exam;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null)
            {
                return false;
            }
            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Exam>> GetAllAsync()
        {
            return await _context.Exams.ToListAsync();
        }

        public async Task<Exam?> GetByIdAsync(int id)
        {
            return await _context.Exams.FindAsync(id);
        }

        public Task<IEnumerable<Exam>> GetExamsByCategoryIdAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Exam>> GetExamsByLevelIdAsync(int levelId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Exam>> GetExamsByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Exam?> UpdateAsync(Exam exam)
        {
            _context.Exams.Update(exam);
            await _context.SaveChangesAsync();
            return exam;
        }
    }
}
