using Coverage.Models;

namespace Coverage.Interfaces;

public interface IClientService
{
    Client CreateClient(ClientInfo clientInfo);
    Client GetClientById(string clientId);
    List<Client> GetAllClients();
    List<Client> GetClientsByClinicId(string clinicId);
    Client UpdateClientClinicById(string clientId, string clinicId);
    bool DeleteClientById(string clientId);

    List<Caretaker> GetCaretakersByClientId(string clientId);
    List<Client> GetClientsByCaretakerId(string caretakerId);
    bool AssignCaretakerToClient(string clientId, string caretakerId);
    bool RemoveCaretakerFromClient(string clientId, string caretakerId);
}