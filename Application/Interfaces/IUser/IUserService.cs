namespace ExamOnline.Interfaces.IUser
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<string?> RegisterAsync(RegisterDTO registerDTO);
        Task<string?> LoginAsync(LoginDTO loginDTO);
        Task<User?> UpdateUserAsync(int id, RegisterDTO registerDTO);
        Task<bool> DeleteUserAsync(int id);
    }
}
