namespace ExamOnline.Interfaces.IRole
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role?> GetByIdAsync(int id);
        Task<Role?> CreateAsync(Role role);
        Task<Role?> UpdateAsync(Role role);
        Task<bool> DeleteAsync(int id);
        Task<Role?> GetRoleByNameAsync(string name);
    }
}
