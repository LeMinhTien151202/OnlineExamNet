using Application.Dtos;
using Microsoft.AspNetCore.Identity;

namespace ExamOnline.Interfaces.IUser
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterAsync(RegisterDTO dto);
        Task<string?> LoginAsync(LoginDTO dto);

        Task<List<UserDTO>> GetAllAsync();
        Task<UserDTO?> GetByNameAsync(string username);
        Task<IdentityResult> UpdateAsync(string id, RegisterDTO dto);
        Task<IdentityResult> DeleteAsync(string id);
    }
}
