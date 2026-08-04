using Authentication.Interfaces;
using Authentication.Models;

namespace Authentication.Services;

public class RightService : IRightService
{
    public Right CreateRight(RightInfo rightInfo)
    {
        throw new NotImplementedException();
    }

    public Right GetRightById(string rightId)
    {
        throw new NotImplementedException();
    }

    public List<Right> GetAllRights()
    {
        throw new NotImplementedException();
    }

    public List<Right> GetRightsByRoleId(string roleId)
    {
        throw new NotImplementedException();
    }

    public List<Right> GetRightsByAdminId(string adminId)
    {
        throw new NotImplementedException();
    }

    public Right UpdateRightById(string rightId, RightInfo rightInfo)
    {
        throw new NotImplementedException();
    }

    public bool DeleteRightById(string rightId)
    {
        throw new NotImplementedException();
    }

    public bool AssignRightToRole(string roleId, string rightId)
    {
        throw new NotImplementedException();
    }

    public bool RemoveRightFromRole(string roleId, string rightId)
    {
        throw new NotImplementedException();
    }
}