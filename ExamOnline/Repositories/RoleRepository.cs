
using ExamOnline.Interfaces.IRole;
using Microsoft.EntityFrameworkCore;

namespace ExamOnline.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ExamOnlineContext _context;

        public RoleRepository(ExamOnlineContext context)
        {
            _context = context;
        }
        public async Task<Role?> CreateAsync(Role role)
        {
           await _context.Roles.AddAsync(role);
           await _context.SaveChangesAsync();
           return role;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return false;
            }
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role?> GetByIdAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public Task<Role?> GetRoleByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Role?> UpdateAsync(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
            return role;

        }
    }
}
