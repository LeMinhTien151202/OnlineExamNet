
namespace ExamOnline.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<User?> CreateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> SearchUsersAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public Task<User?> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
