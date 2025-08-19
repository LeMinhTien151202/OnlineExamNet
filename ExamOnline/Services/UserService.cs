using ExamOnline.Dtos;
using ExamOnline.Interfaces.IUser;

namespace ExamOnline.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<User?> CreateUserAsync(User userDTO)
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

        public Task<User?> UpdateUserAsync(int id, User userDTO)
        {
            throw new NotImplementedException();
        }
    }
}
