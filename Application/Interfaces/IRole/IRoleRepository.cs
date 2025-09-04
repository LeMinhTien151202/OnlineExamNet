using Microsoft.AspNetCore.Identity;

namespace ExamOnline.Interfaces.IRole
{
    public interface IRoleRepository
    {
        //Task<Role?> GetRoleByNameAsync(string name);
        Task<IEnumerable<IdentityRole>> GetAllAsync();
        Task<IdentityRole?> GetByIdAsync(string id);
        Task<IdentityResult> CreateAsync(IdentityRole entity);
        Task<IdentityResult> UpdateAsync(IdentityRole entity);
        Task<IdentityResult> DeleteAsync(IdentityRole entity);

    }
}
