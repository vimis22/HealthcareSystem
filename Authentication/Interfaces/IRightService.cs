using Authentication.Models;

namespace Authentication.Interfaces;

public interface IRightService
{
    Right CreateRight(RightInfo rightInfo);
    Right GetRightById(string rightId);
    List<Right> GetAllRights();
    List<Right> GetRightsByRoleId(string roleId);
    List<Right> GetRightsByAdminId(string adminId);
    Right UpdateRightById(string rightId, RightInfo rightInfo);
    bool DeleteRightById(string rightId);
    bool AssignRightToRole(string roleId, string rightId);
    bool RemoveRightFromRole(string roleId, string rightId);
}