
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
        public Task<User?> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> SearchUsersAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
