using Coverage.Models;

namespace Coverage.Interfaces;

public interface IClientLogService
{
    ClientLog CreateClientLog(string clientId, ClientLogInfo clientLogInfo);
    ClientLog GetClientLogById(string clientLogId);
    List<ClientLog> GetClientLogsByClientId(string clientId);
    List<ClientLog> GetClientLogsByTitle(string title);
    List<ClientLog> GetClientLogsByDescription(string description);
    List<ClientLog> GetClientLogsByDate(DateTime date);
    List<ClientLog> GetClientLogsByType(string type);
    List<ClientLog> GetClientLogsByCaretakerId(string caretakerId);
    List<ClientLog> GetClientLogsByCoverageId(string coverageId);
    ClientLog UpdateClientLogById(string clientLogId, ClientLogInfo clientLogInfo);
    bool DeleteClientLogById(string clientLogId);
}