
using ExamOnline.Interfaces.IUser;
using Microsoft.EntityFrameworkCore;

namespace ExamOnline.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ExamOnlineContext _context;
        public UserRepository(ExamOnlineContext context)
        {
            _context = context;
        }
        public async Task<User?> CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public Task<User?> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> SearchUsersAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
