using HealthCard.Interfaces;
using HealthCard.Models;
using Microsoft.AspNetCore.Mvc;

namespace MainCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthCardController : ControllerBase
{
    private readonly IHealthCardService _healthCardService;

    public HealthCardController(IHealthCardService healthCardService)
    {
        _healthCardService = healthCardService;
    }

    [HttpPost("{clientId}/{clinicId}")]
    public IActionResult Create(string clientId, string clinicId, [FromBody] HealthCardInfo info)
    {
        var healthCard = _healthCardService.CreateHealthCard(clientId, clinicId, info);
        return Ok(healthCard);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var healthCard = _healthCardService.GetHealthCardById(id);
        if (healthCard == null) return NotFound();
        return Ok(healthCard);
    }

    [HttpGet("client/{clientId}")]
    public IActionResult GetByClientId(string clientId)
    {
        var healthCard = _healthCardService.GetHealthCardByClientId(clientId);
        if (healthCard == null) return NotFound();
        return Ok(healthCard);
    }

    [HttpGet("cpr/{cpr}")]
    public IActionResult GetByCpr(string cpr)
    {
        var healthCard = _healthCardService.GetHealthCardByCpr(cpr);
        if (healthCard == null) return NotFound();
        return Ok(healthCard);
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] HealthCardInfo info)
    {
        var healthCard = _healthCardService.UpdateHealthCardById(id, info);
        if (healthCard == null) return NotFound();
        return Ok(healthCard);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var success = _healthCardService.DeleteHealthCardById(id);
        if (!success) return NotFound();
        return Ok();
    }
}
