using Authentication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MainCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authService;

    public AuthenticationController(IAuthenticationService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var result = _authService.AuthenticateUserByEmail(request.Email, request.Password);
        if (!result.Success) return Unauthorized();
        return Ok(result);
    }

    [HttpPatch("{userId}/password")]
    public IActionResult ChangePassword(string userId, [FromBody] ChangePasswordRequest request)
    {
        var success = _authService.ChangePasswordByUserId(userId, request.CurrentPassword, request.NewPassword);
        if (!success) return BadRequest();
        return Ok();
    }
}

public record LoginRequest(string Email, string Password);
public record ChangePasswordRequest(string CurrentPassword, string NewPassword);
