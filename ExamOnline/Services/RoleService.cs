using ExamOnline.Dtos;
using ExamOnline.Interfaces.ILevel;
using ExamOnline.Interfaces.IRole;
using ExamOnline.Repositories;

namespace ExamOnline.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }
        public async Task<Role?> CreateRoleAsync(RoleDTO roleDTO)
        {
            var role = _mapper.Map<Role>(roleDTO);
            var createdRole = await _roleRepository.CreateAsync(role);
            return role;
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            return await _roleRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _roleRepository.GetAllAsync();
        }

        public async Task<Role?> GetRoleByIdAsync(int id)
        {
            return await _roleRepository.GetByIdAsync(id);
        }

        public Task<Role?> GetRoleByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Role?> UpdateRoleAsync(int id, RoleDTO roleDTO)
        {
            var existingRole = await _roleRepository.GetByIdAsync(id);
            if (existingRole == null)
            {
                return null;
            }
            _mapper.Map(roleDTO, existingRole);
            var updatedLevel = await _roleRepository.UpdateAsync(existingRole);
            return updatedLevel;
        }
    }
}
