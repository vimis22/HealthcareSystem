using Coverage.Interfaces;
using Coverage.Models;

namespace Coverage.Services;

public class ClientService : IClientService
{
    public Client CreateClient(ClientInfo clientInfo)
    {
        throw new NotImplementedException();
    }

    public Client GetClientById(string clientId)
    {
        throw new NotImplementedException();
    }

    public List<Client> GetAllClients()
    {
        throw new NotImplementedException();
    }

    public List<Client> GetClientsByClinicId(string clinicId)
    {
        throw new NotImplementedException();
    }

    public Client UpdateClientClinicById(string clientId, string clinicId)
    {
        throw new NotImplementedException();
    }

    public bool DeleteClientById(string clientId)
    {
        throw new NotImplementedException();
    }

    public List<Caretaker> GetCaretakersByClientId(string clientId)
    {
        throw new NotImplementedException();
    }

    public List<Client> GetClientsByCaretakerId(string caretakerId)
    {
        throw new NotImplementedException();
    }

    public bool AssignCaretakerToClient(string clientId, string caretakerId)
    {
        throw new NotImplementedException();
    }

    public bool RemoveCaretakerFromClient(string clientId, string caretakerId)
    {
        throw new NotImplementedException();
    }
}