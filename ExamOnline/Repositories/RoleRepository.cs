
namespace ExamOnline.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public Task<RoleDTO?> CreateRoleAsync(RoleDTO roleDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRoleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RoleDTO>> GetAllRolesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RoleDTO?> GetRoleByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RoleDTO?> GetRoleByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<RoleDTO?> UpdateRoleAsync(RoleDTO roleDTO)
        {
            throw new NotImplementedException();
        }
    }
}
