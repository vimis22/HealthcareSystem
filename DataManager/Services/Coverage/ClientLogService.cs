using Coverage.Interfaces;
using Coverage.Models;

namespace DataManager.Services.Coverage;

public class ClientLogService : IClientLogService
{
    private readonly AppDbContext _db;

    public ClientLogService(AppDbContext db)
    {
        _db = db;
    }

    public ClientLog CreateClientLog(string clientId, ClientLogInfo clientLogInfo)
    {
        var log = new ClientLog
        {
            Id = Guid.NewGuid().ToString(),
            ClientId = clientId,
            Title = clientLogInfo.Title,
            Description = clientLogInfo.Description,
            Date = clientLogInfo.Date,
            Type = clientLogInfo.Type,
            CaretakerId = clientLogInfo.CaretakerId,
            CoverageId = clientLogInfo.CoverageId
        };
        _db.ClientLogs.Add(log);
        _db.SaveChanges();
        return log;
    }

    public ClientLog GetClientLogById(string clientLogId)
    {
        return _db.ClientLogs.FirstOrDefault(l => l.Id == clientLogId);
    }

    public List<ClientLog> GetClientLogsByClientId(string clientId)
    {
        return _db.ClientLogs.Where(l => l.ClientId == clientId).ToList();
    }

    public List<ClientLog> GetClientLogsByTitle(string title)
    {
        return _db.ClientLogs.Where(l => l.Title == title).ToList();
    }

    public List<ClientLog> GetClientLogsByDescription(string description)
    {
        return _db.ClientLogs.Where(l => l.Description == description).ToList();
    }

    public List<ClientLog> GetClientLogsByDate(DateTime date)
    {
        return _db.ClientLogs.Where(l => l.Date == date).ToList();
    }

    public List<ClientLog> GetClientLogsByType(string type)
    {
        return _db.ClientLogs.Where(l => l.Type == type).ToList();
    }

    public List<ClientLog> GetClientLogsByCaretakerId(string caretakerId)
    {
        return _db.ClientLogs.Where(l => l.CaretakerId == caretakerId).ToList();
    }

    public List<ClientLog> GetClientLogsByCoverageId(string coverageId)
    {
        return _db.ClientLogs.Where(l => l.CoverageId == coverageId).ToList();
    }

    public ClientLog UpdateClientLogById(string clientLogId, ClientLogInfo clientLogInfo)
    {
        var log = _db.ClientLogs.FirstOrDefault(l => l.Id == clientLogId);
        if (log == null) return null;
        log.Title = clientLogInfo.Title;
        log.Description = clientLogInfo.Description;
        log.Date = clientLogInfo.Date;
        log.Type = clientLogInfo.Type;
        log.CaretakerId = clientLogInfo.CaretakerId;
        log.CoverageId = clientLogInfo.CoverageId;
        _db.SaveChanges();
        return log;
    }

    public bool DeleteClientLogById(string clientLogId)
    {
        var log = _db.ClientLogs.FirstOrDefault(l => l.Id == clientLogId);
        if (log == null) return false;
        _db.ClientLogs.Remove(log);
        _db.SaveChanges();
        return true;
    }
}
