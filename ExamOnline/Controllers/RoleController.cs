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
            var roles = await _roleService.GetAllRolesAsync();
            return Ok(roles);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var role = await _roleService.GetRoleByIdAsync(id);
            if (role == null)
            {
                throw new NotFoundException($"Role {id} not found");
            }
            return Ok(role);
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
        public async Task<IActionResult> UpdateRole(int id, [FromBody] RoleDTO roleDTO)
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
        public async Task<IActionResult> DeleteRole(int id)
        {
            var result = await _roleService.DeleteRoleAsync(id);
            if (!result)
            {
                throw new NotFoundException($"Role {id} not found");
            }
            return NoContent();
        }
    }
}
