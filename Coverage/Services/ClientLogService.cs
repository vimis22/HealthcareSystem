using Coverage.Interfaces;
using Coverage.Models;

namespace Coverage.Services;

public class ClientLogService : IClientLogService
{
    public ClientLog CreateClientLog(string clientId, ClientLogInfo clientLogInfo)
    {
        throw new NotImplementedException();
    }

    public ClientLog GetClientLogById(string clientLogId)
    {
        throw new NotImplementedException();
    }

    public List<ClientLog> GetClientLogsByClientId(string clientId)
    {
        throw new NotImplementedException();
    }

    public List<ClientLog> GetClientLogsByTitle(string title)
    {
        throw new NotImplementedException();
    }

    public List<ClientLog> GetClientLogsByDescription(string description)
    {
        throw new NotImplementedException();
    }

    public List<ClientLog> GetClientLogsByDate(DateTime date)
    {
        throw new NotImplementedException();
    }

    public List<ClientLog> GetClientLogsByType(string type)
    {
        throw new NotImplementedException();
    }

    public List<ClientLog> GetClientLogsByCaretakerId(string caretakerId)
    {
        throw new NotImplementedException();
    }

    public List<ClientLog> GetClientLogsByCoverageId(string coverageId)
    {
        throw new NotImplementedException();
    }

    public ClientLog UpdateClientLogById(string clientLogId, ClientLogInfo clientLogInfo)
    {
        throw new NotImplementedException();
    }

    public bool DeleteClientLogById(string clientLogId)
    {
        throw new NotImplementedException();
    }
}