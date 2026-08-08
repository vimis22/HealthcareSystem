using Authentication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using User.Models;

namespace MainCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] UserInfo info)
    {
        var admin = _adminService.CreateAdmin(info);
        return Ok(admin);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var admin = _adminService.GetAdminById(id);
        if (admin == null) return NotFound();
        return Ok(admin);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_adminService.GetAllAdmins());
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var success = _adminService.DeleteAdminById(id);
        if (!success) return NotFound();
        return Ok();
    }
}
