using ExamOnline.Dtos;
using ExamOnline.Exceptions;
using ExamOnline.Interfaces.ILevel;
using ExamOnline.Interfaces.IRole;
using ExamOnline.Repositories;
using Microsoft.AspNetCore.Identity;

namespace ExamOnline.Services
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoleRepository _roleRepository;
        public RoleService(IMapper mapper, IUnitOfWork unitOfWork, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _roleRepository = roleRepository;
        }

        public async Task<IdentityResult> CreateRoleAsync(RoleDTO roleDTO)
        {
            if (roleDTO == null || string.IsNullOrWhiteSpace(roleDTO.RoleName))
                throw new BadRequestException("Invalid role data.");
            var role = new IdentityRole(roleDTO.RoleName);
            return await _roleRepository.CreateAsync(role);
        }

        public async Task<IdentityResult> DeleteRoleAsync(string id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null)
                throw new NotFoundException("Role does not exist.");

            return await _roleRepository.DeleteAsync(role);
        }

        public async Task<IEnumerable<IdentityRole>> GetAllRoleAsync()
        {
            return await _roleRepository.GetAllAsync();
        }

        public async Task<IdentityRole?> GetByRoleIdAsync(string id)
        {
            return await _roleRepository.GetByIdAsync(id);
        }

        public async Task<IdentityResult> UpdateRoleAsync(string id, RoleDTO roleDTO)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null)
                throw new NotFoundException("Role does not exist.");

            role.Name = roleDTO.RoleName;
            return await _roleRepository.UpdateAsync(role);
        }
    }
}
