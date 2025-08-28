using ExamOnline.Dtos;
using ExamOnline.Interfaces.ILevel;
using ExamOnline.Interfaces.IRole;
using ExamOnline.Repositories;

namespace ExamOnline.Services
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public RoleService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Role?> CreateRoleAsync(RoleDTO roleDTO)
        {
            var role = _mapper.Map<Role>(roleDTO);
            var createdRole = await _unitOfWork.Roles.CreateAsync(role);
            return role;
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            return await _unitOfWork.Roles.DeleteAsync(id);
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _unitOfWork.Roles.GetAllAsync();
        }

        public async Task<Role?> GetRoleByIdAsync(int id)
        {
            return await _unitOfWork.Roles.GetByIdAsync(id);
        }

        public Task<Role?> GetRoleByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Role?> UpdateRoleAsync(int id, RoleDTO roleDTO)
        {
            var existingRole = await _unitOfWork.Roles.GetByIdAsync(id);
            if (existingRole == null)
            {
                return null;
            }
            _mapper.Map(roleDTO, existingRole);
            var updatedLevel = await _unitOfWork.Roles.UpdateAsync(existingRole);
            return updatedLevel;
        }
    }
}
