using Language.Interfaces;
using Language.Models;
using Microsoft.AspNetCore.Mvc;

namespace MainCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LanguageController : ControllerBase
{
    private readonly ILanguageService _languageService;

    public LanguageController(ILanguageService languageService)
    {
        _languageService = languageService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] LanguageInfo info)
    {
        var language = _languageService.CreateLanguage(info);
        return Ok(language);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var language = _languageService.GetLanguageById(id);
        if (language == null) return NotFound();
        return Ok(language);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_languageService.GetAllLanguages());
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] LanguageInfo info)
    {
        var language = _languageService.UpdateLanguageById(id, info);
        if (language == null) return NotFound();
        return Ok(language);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var success = _languageService.DeleteLanguageById(id);
        if (!success) return NotFound();
        return Ok();
    }
}
