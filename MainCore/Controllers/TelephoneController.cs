using Microsoft.AspNetCore.Mvc;
using User.Interfaces;
using User.Models;

namespace MainCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TelephoneController : ControllerBase
{
    private readonly ITelephoneService _telephoneService;

    public TelephoneController(ITelephoneService telephoneService)
    {
        _telephoneService = telephoneService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] TelephoneInfo info)
    {
        var telephone = _telephoneService.CreateTelephone(info);
        return Ok(telephone);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var telephone = _telephoneService.GetTelephoneById(id);
        if (telephone == null) return NotFound();
        return Ok(telephone);
    }

    [HttpGet("user/{userId}")]
    public IActionResult GetByUserId(string userId)
    {
        return Ok(_telephoneService.GetTelephonesByUserId(userId));
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] TelephoneInfo info)
    {
        var telephone = _telephoneService.UpdateTelephoneById(id, info);
        if (telephone == null) return NotFound();
        return Ok(telephone);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var success = _telephoneService.DeleteTelephoneById(id);
        if (!success) return NotFound();
        return Ok();
    }

    [HttpPost("user/{userId}/assign/{telephoneId}")]
    public IActionResult AssignToUser(string userId, string telephoneId)
    {
        var success = _telephoneService.AssignTelephoneToUser(userId, telephoneId);
        if (!success) return NotFound();
        return Ok();
    }

    [HttpDelete("user/{userId}/remove/{telephoneId}")]
    public IActionResult RemoveFromUser(string userId, string telephoneId)
    {
        var success = _telephoneService.RemoveTelephoneFromUser(userId, telephoneId);
        if (!success) return NotFound();
        return Ok();
    }
}
