using ExamOnline.Exceptions;
using ExamOnline.Interfaces.IExam;
using ExamOnline.Interfaces.IRole;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleService.GetAllRoleAsync();
           var roleDTOs = roles.Select(role => new RoleDTO
            {
                RoleName = role.Name
            }).ToList();
            return Ok(roleDTOs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(string id)
        {
            var role = await _roleService.GetByRoleIdAsync(id);
            if (role == null)
            {
                throw new NotFoundException($"Role {id} not found");
            }
            RoleDTO result = new RoleDTO
            {
                RoleName = role.Name
            };
            return Ok(result);
        }
        [HttpPost]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateRole([FromBody] RoleDTO roleDTO)
        {
            if (roleDTO == null)
            {
                throw new BadRequestException("Invalid role data");
            }
            var createdRole = await _roleService.CreateRoleAsync(roleDTO);
            return Ok(createdRole);
        }
        [HttpPut("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateRole(string id, [FromBody] RoleDTO roleDTO)
        {
            var updatedRole = await _roleService.UpdateRoleAsync(id, roleDTO);
            if (updatedRole == null)
            {
                throw new NotFoundException($"Role {id} not found");
            }
            return Ok(updatedRole);
        }
        [HttpDelete("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var result = await _roleService.DeleteRoleAsync(id);
            if (result==null)
            {
                throw new NotFoundException($"Role {id} not found");
            }
            return NoContent();
        }
    }
}
