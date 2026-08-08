using Authentication.Interfaces;
using Authentication.Models;
using Microsoft.AspNetCore.Mvc;

namespace MainCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RightController : ControllerBase
{
    private readonly IRightService _rightService;

    public RightController(IRightService rightService)
    {
        _rightService = rightService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] RightInfo info)
    {
        var right = _rightService.CreateRight(info);
        return Ok(right);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var right = _rightService.GetRightById(id);
        if (right == null) return NotFound();
        return Ok(right);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_rightService.GetAllRights());
    }

    [HttpGet("role/{roleId}")]
    public IActionResult GetByRoleId(string roleId)
    {
        return Ok(_rightService.GetRightsByRoleId(roleId));
    }

    [HttpGet("admin/{adminId}")]
    public IActionResult GetByAdminId(string adminId)
    {
        return Ok(_rightService.GetRightsByAdminId(adminId));
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] RightInfo info)
    {
        var right = _rightService.UpdateRightById(id, info);
        if (right == null) return NotFound();
        return Ok(right);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var success = _rightService.DeleteRightById(id);
        if (!success) return NotFound();
        return Ok();
    }

    [HttpPost("role/{roleId}/assign/{rightId}")]
    public IActionResult AssignToRole(string roleId, string rightId)
    {
        var success = _rightService.AssignRightToRole(roleId, rightId);
        if (!success) return NotFound();
        return Ok();
    }

    [HttpDelete("role/{roleId}/remove/{rightId}")]
    public IActionResult RemoveFromRole(string roleId, string rightId)
    {
        var success = _rightService.RemoveRightFromRole(roleId, rightId);
        if (!success) return NotFound();
        return Ok();
    }
}
