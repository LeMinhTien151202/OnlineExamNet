namespace ExamOnline.Interfaces.IUser
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> CreateUserAsync(User userDTO);
        Task<User?> UpdateUserAsync(int id,User userDTO);
        Task<bool> DeleteUserAsync(int id);
        Task<User?> GetUserByEmailAsync(string email);
        Task<IEnumerable<User>> SearchUsersAsync(string searchTerm);
    }
}
