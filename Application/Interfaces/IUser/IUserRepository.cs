using Microsoft.AspNetCore.Identity;

namespace ExamOnline.Interfaces.IUser
{
    public interface IUserRepository
    {
        Task<IdentityResult> CreateAsync(IdentityUser user, string password);
        Task<IdentityUser?> FindByNameAsync(string username);
        Task<IdentityUser?> FindByIdAsync(string id);
        Task<List<IdentityUser>> GetAllAsync();
        Task<IdentityResult> UpdateAsync(IdentityUser user);
        Task<IdentityResult> DeleteAsync(IdentityUser user);

        Task<bool> CheckPasswordAsync(IdentityUser user, string password);
        Task<IList<string>> GetRolesAsync(IdentityUser user);
        Task<IdentityResult> AddToRoleAsync(IdentityUser user, string role);
    }
}
