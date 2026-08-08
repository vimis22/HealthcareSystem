using HealthcareProvider.Interfaces;
using HealthcareProvider.Models;
using Microsoft.AspNetCore.Mvc;

namespace MainCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClinicController : ControllerBase
{
    private readonly IClinicService _clinicService;

    public ClinicController(IClinicService clinicService)
    {
        _clinicService = clinicService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] ClinicInfo info)
    {
        var clinic = _clinicService.CreateClinic(info);
        return Ok(clinic);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var clinic = _clinicService.GetClinicById(id);
        if (clinic == null) return NotFound();
        return Ok(clinic);
    }

    [HttpGet("name/{name}")]
    public IActionResult GetByName(string name)
    {
        return Ok(_clinicService.GetClinicsByName(name));
    }

    [HttpGet("city/{cityId}")]
    public IActionResult GetByCityId(string cityId)
    {
        return Ok(_clinicService.GetClinicsByCityId(cityId));
    }

    [HttpGet("streetname/{streetname}")]
    public IActionResult GetByStreetname(string streetname)
    {
        return Ok(_clinicService.GetClinicsByStreetname(streetname));
    }

    [HttpGet("email/{email}")]
    public IActionResult GetByEmail(string email)
    {
        return Ok(_clinicService.GetClinicsByEmail(email));
    }

    [HttpGet("telephone/{telephone}")]
    public IActionResult GetByTelephone(string telephone)
    {
        return Ok(_clinicService.GetClinicsByTelephone(telephone));
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] ClinicInfo info)
    {
        var clinic = _clinicService.UpdateClinicById(id, info);
        if (clinic == null) return NotFound();
        return Ok(clinic);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var success = _clinicService.DeleteClinicById(id);
        if (!success) return NotFound();
        return Ok();
    }
}
