using Microsoft.AspNetCore.Mvc;
using SystemLog.Interfaces;
using SystemLog.Models;

namespace MainCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SystemLogController : ControllerBase
{
    private readonly ISystemLogService _systemLogService;

    public SystemLogController(ISystemLogService systemLogService)
    {
        _systemLogService = systemLogService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] SystemLogInfo info)
    {
        var log = _systemLogService.CreateSystemLog(info);
        return Ok(log);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var log = _systemLogService.GetSystemLogById(id);
        if (log == null) return NotFound();
        return Ok(log);
    }

    [HttpGet("title/{title}")]
    public IActionResult GetByTitle(string title)
    {
        return Ok(_systemLogService.GetSystemLogsByTitle(title));
    }

    [HttpGet("success/{success}")]
    public IActionResult GetBySuccess(bool success)
    {
        return Ok(_systemLogService.GetSystemLogsBySuccess(success));
    }

    [HttpGet("error/{error}")]
    public IActionResult GetByError(bool error)
    {
        return Ok(_systemLogService.GetSystemLogsByError(error));
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] SystemLogInfo info)
    {
        var log = _systemLogService.UpdateSystemLogById(id, info);
        if (log == null) return NotFound();
        return Ok(log);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var success = _systemLogService.DeleteSystemLogById(id);
        if (!success) return NotFound();
        return Ok();
    }
}
