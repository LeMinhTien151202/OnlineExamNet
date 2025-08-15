
namespace ExamOnline.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<RoleDTO>> GetAllRolesAsync();
        Task<RoleDTO?> GetRoleByIdAsync(int id);
        Task<RoleDTO?> CreateRoleAsync(RoleDTO roleDTO);
        Task<RoleDTO?> UpdateRoleAsync(RoleDTO roleDTO);
        Task<bool> DeleteRoleAsync(int id);
        Task<RoleDTO?> GetRoleByNameAsync(string name);
    }
}
