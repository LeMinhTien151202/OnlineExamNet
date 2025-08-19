
using ExamOnline.Interfaces.IUser;

namespace ExamOnline.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<User?> CreateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> SearchUsersAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public Task<User?> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
