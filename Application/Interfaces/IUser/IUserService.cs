using Microsoft.AspNetCore.Identity;

namespace ExamOnline.Interfaces.IUser
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterAsync(RegisterDTO dto);
        Task<string?> LoginAsync(LoginDTO dto);

        Task<List<IdentityUser>> GetAllAsync();
        Task<IdentityUser?> GetByNameAsync(string username);
        Task<IdentityResult> UpdateAsync(RegisterDTO dto);
        Task<IdentityResult> DeleteAsync(string id);
    }
}
