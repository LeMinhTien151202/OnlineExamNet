
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

        public Task<Role?> GetRoleByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
