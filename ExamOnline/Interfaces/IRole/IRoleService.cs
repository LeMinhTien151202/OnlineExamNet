namespace ExamOnline.Interfaces.IRole
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role?> GetRoleByIdAsync(int id);
        Task<Role?> CreateRoleAsync(RoleDTO roleDTO);
        Task<Role?> UpdateRoleAsync(RoleDTO roleDTO);
        Task<bool> DeleteRoleAsync(int id);
        Task<Role?> GetRoleByNameAsync(string name);
    }
}
