using Microsoft.AspNetCore.Identity;

namespace ExamOnline.Interfaces.IRole
{
    public interface IRoleService
    {
        Task<IEnumerable<IdentityRole>> GetAllRoleAsync();
        Task<IdentityRole?> GetByRoleIdAsync(string id);
        Task<IdentityResult> CreateRoleAsync(RoleDTO roleDTO);
        Task<IdentityResult> UpdateRoleAsync(string id, RoleDTO roleDTO);
        Task<IdentityResult> DeleteRoleAsync(string id);
    }
}
