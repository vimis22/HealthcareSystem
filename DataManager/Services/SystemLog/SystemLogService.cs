using SystemLog.Interfaces;
using SystemLog.Models;

namespace DataManager.Services.SystemLog;

public class SystemLogService : ISystemLogService
{
    private readonly AppDbContext _db;

    public SystemLogService(AppDbContext db)
    {
        _db = db;
    }

    public global::SystemLog.Models.SystemLog CreateSystemLog(SystemLogInfo systemLogInfo)
    {
        var log = new global::SystemLog.Models.SystemLog
        {
            Id = Guid.NewGuid().ToString(),
            Title = systemLogInfo.Title,
            Description = systemLogInfo.Description,
            Date = systemLogInfo.Date,
            Success = systemLogInfo.Success,
            Error = systemLogInfo.Error
        };
        _db.SystemLogs.Add(log);
        _db.SaveChanges();
        return log;
    }

    public global::SystemLog.Models.SystemLog GetSystemLogById(string systemLogId)
    {
        return _db.SystemLogs.FirstOrDefault(l => l.Id == systemLogId);
    }

    public List<global::SystemLog.Models.SystemLog> GetSystemLogsByTitle(string title)
    {
        return _db.SystemLogs.Where(l => l.Title == title).ToList();
    }

    public List<global::SystemLog.Models.SystemLog> GetSystemLogsByDescription(string description)
    {
        return _db.SystemLogs.Where(l => l.Description == description).ToList();
    }

    public List<global::SystemLog.Models.SystemLog> GetSystemLogsByDate(DateTime date)
    {
        return _db.SystemLogs.Where(l => l.Date == date).ToList();
    }

    public List<global::SystemLog.Models.SystemLog> GetSystemLogsBySuccess(bool success)
    {
        return _db.SystemLogs.Where(l => l.Success == success).ToList();
    }

    public List<global::SystemLog.Models.SystemLog> GetSystemLogsByError(bool error)
    {
        return _db.SystemLogs.Where(l => l.Error == error).ToList();
    }

    public global::SystemLog.Models.SystemLog UpdateSystemLogById(string systemLogId, SystemLogInfo systemLogInfo)
    {
        var log = _db.SystemLogs.FirstOrDefault(l => l.Id == systemLogId);
        if (log == null) return null;
        log.Title = systemLogInfo.Title;
        log.Description = systemLogInfo.Description;
        log.Date = systemLogInfo.Date;
        log.Success = systemLogInfo.Success;
        log.Error = systemLogInfo.Error;
        _db.SaveChanges();
        return log;
    }

    public bool DeleteSystemLogById(string systemLogId)
    {
        var log = _db.SystemLogs.FirstOrDefault(l => l.Id == systemLogId);
        if (log == null) return false;
        _db.SystemLogs.Remove(log);
        _db.SaveChanges();
        return true;
    }
}
