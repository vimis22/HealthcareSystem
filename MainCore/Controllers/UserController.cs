using Microsoft.AspNetCore.Mvc;
using User.Interfaces;
using User.Models;

namespace MainCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var user = _userService.GetUserById(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpGet("firstname/{firstname}")]
    public IActionResult GetByFirstname(string firstname)
    {
        return Ok(_userService.GetUsersByFirstname(firstname));
    }

    [HttpGet("lastname/{lastname}")]
    public IActionResult GetByLastname(string lastname)
    {
        return Ok(_userService.GetUsersByLastname(lastname));
    }

    [HttpGet("city/{cityId}")]
    public IActionResult GetByCityId(string cityId)
    {
        return Ok(_userService.GetUsersByCityId(cityId));
    }

    [HttpPost]
    public IActionResult Create([FromBody] UserInfo info)
    {
        var user = _userService.CreateUser(info);
        return Ok(user);
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] UserInfo info)
    {
        var user = _userService.UpdateUserById(id, info);
        if (user == null) return NotFound();
        return Ok(user);
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var success = _userService.DeleteUserById(id);
        if (!success) return NotFound();
        return Ok();
    }
}