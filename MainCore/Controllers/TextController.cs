using Language.Interfaces;
using Language.Models;
using Microsoft.AspNetCore.Mvc;

namespace MainCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TextController : ControllerBase
{
    private readonly ITextService _textService;

    public TextController(ITextService textService)
    {
        _textService = textService;
    }

    [HttpPost("{languageId}")]
    public IActionResult Create(string languageId, [FromBody] TextInfo info)
    {
        var text = _textService.CreateText(languageId, info);
        return Ok(text);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var text = _textService.GetTextById(id);
        if (text == null) return NotFound();
        return Ok(text);
    }

    [HttpGet("language/{languageId}")]
    public IActionResult GetByLanguageId(string languageId)
    {
        return Ok(_textService.GetTextsByLanguageId(languageId));
    }

    [HttpGet("language/{languageId}/fieldname/{fieldname}")]
    public IActionResult GetByLanguageAndFieldname(string languageId, string fieldname)
    {
        var text = _textService.GetTextByLanguageAndFieldname(languageId, fieldname);
        if (text == null) return NotFound();
        return Ok(text);
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] TextInfo info)
    {
        var text = _textService.UpdateTextById(id, info);
        if (text == null) return NotFound();
        return Ok(text);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var success = _textService.DeleteTextById(id);
        if (!success) return NotFound();
        return Ok();
    }
}
