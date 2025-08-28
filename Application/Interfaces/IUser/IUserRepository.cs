namespace ExamOnline.Interfaces.IUser
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);
        Task<IEnumerable<User>> SearchUsersAsync(string searchTerm);
    }
}
