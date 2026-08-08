using Coverage.Interfaces;
using Coverage.Models;
using Microsoft.AspNetCore.Mvc;

namespace MainCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoverageController : ControllerBase
{
    private readonly ICoverageService _coverageService;

    public CoverageController(ICoverageService coverageService)
    {
        _coverageService = coverageService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] CoverageInfo info)
    {
        var coverage = _coverageService.CreateCoverage(info);
        return Ok(coverage);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var coverage = _coverageService.GetCoverageById(id);
        if (coverage == null) return NotFound();
        return Ok(coverage);
    }

    [HttpGet("number/{coverageNumber}")]
    public IActionResult GetByCoverageNumber(string coverageNumber)
    {
        var coverage = _coverageService.GetCoverageByCoverageNumber(coverageNumber);
        if (coverage == null) return NotFound();
        return Ok(coverage);
    }

    [HttpGet("client/{clientId}")]
    public IActionResult GetByClientId(string clientId)
    {
        return Ok(_coverageService.GetCoveragesByClientId(clientId));
    }

    [HttpGet("type/{type}")]
    public IActionResult GetByType(string type)
    {
        return Ok(_coverageService.GetCoveragesByType(type));
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] CoverageInfo info)
    {
        var coverage = _coverageService.UpdateCoverageById(id, info);
        if (coverage == null) return NotFound();
        return Ok(coverage);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var success = _coverageService.DeleteCoverageById(id);
        if (!success) return NotFound();
        return Ok();
    }

    [HttpPost("{clientId}/assign/{coverageId}")]
    public IActionResult AssignToClient(string clientId, string coverageId)
    {
        var success = _coverageService.AssignCoverageToClient(clientId, coverageId);
        if (!success) return NotFound();
        return Ok();
    }

    [HttpDelete("{clientId}/remove/{coverageId}")]
    public IActionResult RemoveFromClient(string clientId, string coverageId)
    {
        var success = _coverageService.RemoveCoverageFromClient(clientId, coverageId);
        if (!success) return NotFound();
        return Ok();
    }
}
