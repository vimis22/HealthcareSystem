using Authentication.Interfaces;
using Authentication.Models;
using Microsoft.AspNetCore.Mvc;

namespace MainCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] RoleInfo info)
    {
        var role = _roleService.CreateRole(info);
        return Ok(role);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var role = _roleService.GetRoleById(id);
        if (role == null) return NotFound();
        return Ok(role);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_roleService.GetAllRoles());
    }

    [HttpGet("admin/{adminId}")]
    public IActionResult GetByAdminId(string adminId)
    {
        return Ok(_roleService.GetRolesByAdminId(adminId));
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] RoleInfo info)
    {
        var role = _roleService.UpdateRoleById(id, info);
        if (role == null) return NotFound();
        return Ok(role);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var success = _roleService.DeleteRoleById(id);
        if (!success) return NotFound();
        return Ok();
    }

    [HttpPost("{adminId}/assign/{roleId}")]
    public IActionResult AssignToAdmin(string adminId, string roleId)
    {
        var success = _roleService.AssignRoleToAdmin(adminId, roleId);
        if (!success) return NotFound();
        return Ok();
    }

    [HttpDelete("{adminId}/remove/{roleId}")]
    public IActionResult RemoveFromAdmin(string adminId, string roleId)
    {
        var success = _roleService.RemoveRoleFromAdmin(adminId, roleId);
        if (!success) return NotFound();
        return Ok();
    }
}
