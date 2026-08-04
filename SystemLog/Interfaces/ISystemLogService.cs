using SystemLog.Models;

namespace SystemLog.Interfaces;

public interface ISystemLogService
{
    Models.SystemLog CreateSystemLog(SystemLogInfo systemLogInfo);
    Models.SystemLog GetSystemLogById(string systemLogId);
    List<Models.SystemLog> GetSystemLogsByTitle(string title);
    List<Models.SystemLog> GetSystemLogsByDescription(string description);
    List<Models.SystemLog> GetSystemLogsByDate(DateTime date);
    List<Models.SystemLog> GetSystemLogsBySuccess(bool success);
    List<Models.SystemLog> GetSystemLogsByError(bool error);
    Models.SystemLog UpdateSystemLogById(string systemLogId, SystemLogInfo systemLogInfo);
    bool DeleteSystemLogById(string systemLogId);
}