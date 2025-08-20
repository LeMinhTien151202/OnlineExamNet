namespace ExamOnline.Interfaces.IUser
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> CreateAsync(User user);
        Task<bool> DeleteAsync(int id);
        Task<User?> GetUserByEmailAsync(string email);
        Task<IEnumerable<User>> SearchUsersAsync(string searchTerm);
        Task<User?> UpdateAsync(User user);
    }
}
