using Coverage.Interfaces;
using Coverage.Models;
using Microsoft.EntityFrameworkCore;

namespace DataManager.Services.Coverage;

public class ClientService : IClientService
{
    private readonly AppDbContext _db;

    public ClientService(AppDbContext db)
    {
        _db = db;
    }

    public Client CreateClient(ClientInfo clientInfo)
    {
        var client = new Client
        {
            Id = Guid.NewGuid().ToString(),
            Firstname = clientInfo.Firstname,
            Middlename = clientInfo.Middlename,
            Lastname = clientInfo.Lastname,
            Streetname = clientInfo.Streetname,
            CityId = clientInfo.CityId,
            Password = clientInfo.Password,
            ClinicId = clientInfo.ClinicId
        };
        _db.Clients.Add(client);
        _db.SaveChanges();
        return client;
    }

    public Client GetClientById(string clientId)
    {
        return _db.Clients.FirstOrDefault(c => c.Id == clientId);
    }

    public List<Client> GetAllClients()
    {
        return _db.Clients.ToList();
    }

    public List<Client> GetClientsByClinicId(string clinicId)
    {
        return _db.Clients.Where(c => c.ClinicId == clinicId).ToList();
    }

    public Client UpdateClientClinicById(string clientId, string clinicId)
    {
        var client = _db.Clients.FirstOrDefault(c => c.Id == clientId);
        if (client == null) return null;
        client.ClinicId = clinicId;
        _db.SaveChanges();
        return client;
    }

    public bool DeleteClientById(string clientId)
    {
        var client = _db.Clients.FirstOrDefault(c => c.Id == clientId);
        if (client == null) return false;
        _db.Clients.Remove(client);
        _db.SaveChanges();
        return true;
    }

    public List<Caretaker> GetCaretakersByClientId(string clientId)
    {
        var caretakerIds = _db.Set<Dictionary<string, object>>("ClientCaretakers")
            .Where(cc => EF.Property<string>(cc, "ClientId") == clientId)
            .Select(cc => EF.Property<string>(cc, "CaretakerId"))
            .ToList();
        return _db.Caretakers.Where(c => caretakerIds.Contains(c.Id)).ToList();
    }

    public List<Client> GetClientsByCaretakerId(string caretakerId)
    {
        var clientIds = _db.Set<Dictionary<string, object>>("ClientCaretakers")
            .Where(cc => EF.Property<string>(cc, "CaretakerId") == caretakerId)
            .Select(cc => EF.Property<string>(cc, "ClientId"))
            .ToList();
        return _db.Clients.Where(c => clientIds.Contains(c.Id)).ToList();
    }

    public bool AssignCaretakerToClient(string clientId, string caretakerId)
    {
        var client = _db.Clients.FirstOrDefault(c => c.Id == clientId);
        var caretaker = _db.Caretakers.FirstOrDefault(c => c.Id == caretakerId);
        if (client == null || caretaker == null) return false;
        _db.Set<Dictionary<string, object>>("ClientCaretakers").Add(new Dictionary<string, object>
        {
            { "ClientId", clientId },
            { "CaretakerId", caretakerId }
        });
        _db.SaveChanges();
        return true;
    }

    public bool RemoveCaretakerFromClient(string clientId, string caretakerId)
    {
        var entry = _db.Set<Dictionary<string, object>>("ClientCaretakers")
            .FirstOrDefault(cc => EF.Property<string>(cc, "ClientId") == clientId && EF.Property<string>(cc, "CaretakerId") == caretakerId);
        if (entry == null) return false;
        _db.Set<Dictionary<string, object>>("ClientCaretakers").Remove(entry);
        _db.SaveChanges();
        return true;
    }
}
