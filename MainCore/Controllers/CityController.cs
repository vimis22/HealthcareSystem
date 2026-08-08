using HealthcareProvider.Interfaces;
using HealthcareProvider.Models;
using Microsoft.AspNetCore.Mvc;

namespace MainCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CityController : ControllerBase
{
    private readonly ICityService _cityService;

    public CityController(ICityService cityService)
    {
        _cityService = cityService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] CityInfo info)
    {
        var city = _cityService.CreateCity(info);
        return Ok(city);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var city = _cityService.GetCityById(id);
        if (city == null) return NotFound();
        return Ok(city);
    }

    [HttpGet("postalcode/{postalcode}")]
    public IActionResult GetByPostalcode(string postalcode)
    {
        return Ok(_cityService.GetCitiesByPostalcode(postalcode));
    }

    [HttpGet("region/{region}")]
    public IActionResult GetByRegion(string region)
    {
        return Ok(_cityService.GetCitiesByRegion(region));
    }

    [HttpGet("country/{country}")]
    public IActionResult GetByCountry(string country)
    {
        return Ok(_cityService.GetCitiesByCountry(country));
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] CityInfo info)
    {
        var city = _cityService.UpdateCityById(id, info);
        if (city == null) return NotFound();
        return Ok(city);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var success = _cityService.DeleteCityById(id);
        if (!success) return NotFound();
        return Ok();
    }
}
