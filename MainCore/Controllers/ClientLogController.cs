using Coverage.Interfaces;
using Coverage.Models;
using Microsoft.AspNetCore.Mvc;

namespace MainCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientLogController : ControllerBase
{
    private readonly IClientLogService _clientLogService;

    public ClientLogController(IClientLogService clientLogService)
    {
        _clientLogService = clientLogService;
    }

    [HttpPost("{clientId}")]
    public IActionResult Create(string clientId, [FromBody] ClientLogInfo info)
    {
        var log = _clientLogService.CreateClientLog(clientId, info);
        return Ok(log);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var log = _clientLogService.GetClientLogById(id);
        if (log == null) return NotFound();
        return Ok(log);
    }

    [HttpGet("client/{clientId}")]
    public IActionResult GetByClientId(string clientId)
    {
        return Ok(_clientLogService.GetClientLogsByClientId(clientId));
    }

    [HttpGet("type/{type}")]
    public IActionResult GetByType(string type)
    {
        return Ok(_clientLogService.GetClientLogsByType(type));
    }

    [HttpGet("caretaker/{caretakerId}")]
    public IActionResult GetByCaretakerId(string caretakerId)
    {
        return Ok(_clientLogService.GetClientLogsByCaretakerId(caretakerId));
    }

    [HttpGet("coverage/{coverageId}")]
    public IActionResult GetByCoverageId(string coverageId)
    {
        return Ok(_clientLogService.GetClientLogsByCoverageId(coverageId));
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] ClientLogInfo info)
    {
        var log = _clientLogService.UpdateClientLogById(id, info);
        if (log == null) return NotFound();
        return Ok(log);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var success = _clientLogService.DeleteClientLogById(id);
        if (!success) return NotFound();
        return Ok();
    }
}
