using Coverage.Interfaces;
using Coverage.Models;
using Microsoft.AspNetCore.Mvc;

namespace MainCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] ClientInfo info)
    {
        var client = _clientService.CreateClient(info);
        return Ok(client);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var client = _clientService.GetClientById(id);
        if (client == null) return NotFound();
        return Ok(client);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_clientService.GetAllClients());
    }

    [HttpGet("clinic/{clinicId}")]
    public IActionResult GetByClinicId(string clinicId)
    {
        return Ok(_clientService.GetClientsByClinicId(clinicId));
    }

    [HttpPatch("{id}/clinic/{clinicId}")]
    public IActionResult UpdateClinic(string id, string clinicId)
    {
        var client = _clientService.UpdateClientClinicById(id, clinicId);
        if (client == null) return NotFound();
        return Ok(client);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var success = _clientService.DeleteClientById(id);
        if (!success) return NotFound();
        return Ok();
    }

    [HttpGet("{id}/caretakers")]
    public IActionResult GetCaretakers(string id)
    {
        return Ok(_clientService.GetCaretakersByClientId(id));
    }

    [HttpPost("{id}/caretakers/{caretakerId}")]
    public IActionResult AssignCaretaker(string id, string caretakerId)
    {
        var success = _clientService.AssignCaretakerToClient(id, caretakerId);
        if (!success) return NotFound();
        return Ok();
    }

    [HttpDelete("{id}/caretakers/{caretakerId}")]
    public IActionResult RemoveCaretaker(string id, string caretakerId)
    {
        var success = _clientService.RemoveCaretakerFromClient(id, caretakerId);
        if (!success) return NotFound();
        return Ok();
    }
}
