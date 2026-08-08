using Microsoft.AspNetCore.Mvc;
using User.Interfaces;
using User.Models;

namespace MainCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmailController : ControllerBase
{
    private readonly IEmailService _emailService;

    public EmailController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost("{userId}")]
    public IActionResult Create(string userId, [FromBody] EmailInfo info)
    {
        var email = _emailService.CreateEmail(userId, info);
        return Ok(email);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var email = _emailService.GetEmailById(id);
        if (email == null) return NotFound();
        return Ok(email);
    }

    [HttpGet("user/{userId}")]
    public IActionResult GetByUserId(string userId)
    {
        return Ok(_emailService.GetEmailsByUserId(userId));
    }

    [HttpGet("user/{userId}/primary")]
    public IActionResult GetPrimaryByUserId(string userId)
    {
        var email = _emailService.GetPrimaryEmailByUserId(userId);
        if (email == null) return NotFound();
        return Ok(email);
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] EmailInfo info)
    {
        var email = _emailService.UpdateEmailById(id, info);
        if (email == null) return NotFound();
        return Ok(email);
    }

    [HttpPatch("user/{userId}/primary/{emailId}")]
    public IActionResult SetPrimary(string userId, string emailId)
    {
        var success = _emailService.SetPrimaryEmailForUser(userId, emailId);
        if (!success) return NotFound();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var success = _emailService.DeleteEmailById(id);
        if (!success) return NotFound();
        return Ok();
    }
}
