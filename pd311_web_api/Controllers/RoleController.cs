using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pd311_web_api.BLL.DTOs.Role;
using pd311_web_api.BLL.Services.Role;
using static pd311_web_api.DAL.Entities.IdentityEntities;

namespace pd311_web_api.Controllers
{
    [ApiController]
    [Route("api/role")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllAsync()
        {
            var roles = await _roleService.GetAllAsync();
            return Ok(roles);
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(string? id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("Id required");

            var result = await _roleService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] RoleDto dto)
        {
            var result = await _roleService.CreateAsync(dto);
            return result ? Ok("Role created") : BadRequest("Role not created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] RoleDto dto)
        {
            var result = await _roleService.UpdateAsync(dto);
            return result ? Ok("Role updated") : BadRequest("Role not updated");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string? id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("Id required");

            var result = await _roleService.DeleteAsync(id);
            return result ? Ok("Role deleted") : BadRequest("Role not deleted");
        }
    }
}
