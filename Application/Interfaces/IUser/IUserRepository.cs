using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ExamOnline.Interfaces.IUser
{
    public interface IUserRepository
    {
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);
        Task<ApplicationUser?> FindByNameAsync(string username);
        Task<ApplicationUser?> FindByIdAsync(string id);
        Task<List<ApplicationUser>> GetAllAsync();
        Task<IdentityResult> UpdateAsync(ApplicationUser user);
        Task<IdentityResult> DeleteAsync(ApplicationUser user);

        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        Task<IList<string>> GetRolesAsync(ApplicationUser user);
        Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role);
    }
}
