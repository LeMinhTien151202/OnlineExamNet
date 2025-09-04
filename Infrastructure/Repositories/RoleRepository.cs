
using ExamOnline.Interfaces.IRole;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExamOnline.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleRepository(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> CreateAsync(IdentityRole entity)
        {
            return await _roleManager.CreateAsync(entity);
        }

        public async Task<IdentityResult> DeleteAsync(IdentityRole entity)
        {
            return await _roleManager.DeleteAsync(entity);
        }

        public async Task<IEnumerable<IdentityRole>> GetAllAsync()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<IdentityRole?> GetByIdAsync(string id)
        {
            return await _roleManager.FindByIdAsync(id);
        }

        public async Task<IdentityResult> UpdateAsync(IdentityRole entity)
        {
            return await _roleManager.UpdateAsync(entity);
        }

        //public Task<Role?> GetRoleByNameAsync(string name)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
