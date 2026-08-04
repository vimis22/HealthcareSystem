using SystemLog.Interfaces;
using SystemLog.Models;

namespace SystemLog.Services;

public class SystemLogService : ISystemLogService
{
    public Models.SystemLog CreateSystemLog(SystemLogInfo systemLogInfo)
    {
        throw new NotImplementedException();
    }

    public Models.SystemLog GetSystemLogById(string systemLogId)
    {
        throw new NotImplementedException();
    }

    public List<Models.SystemLog> GetSystemLogsByTitle(string title)
    {
        throw new NotImplementedException();
    }

    public List<Models.SystemLog> GetSystemLogsByDescription(string description)
    {
        throw new NotImplementedException();
    }

    public List<Models.SystemLog> GetSystemLogsByDate(DateTime date)
    {
        throw new NotImplementedException();
    }

    public List<Models.SystemLog> GetSystemLogsBySuccess(bool success)
    {
        throw new NotImplementedException();
    }

    public List<Models.SystemLog> GetSystemLogsByError(bool error)
    {
        throw new NotImplementedException();
    }

    public Models.SystemLog UpdateSystemLogById(string systemLogId, SystemLogInfo systemLogInfo)
    {
        throw new NotImplementedException();
    }

    public bool DeleteSystemLogById(string systemLogId)
    {
        throw new NotImplementedException();
    }
}