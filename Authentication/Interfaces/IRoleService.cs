using Authentication.Models;

namespace Authentication.Interfaces;

public interface IRoleService
{
    Role CreateRole(RoleInfo roleInfo);
    Role GetRoleById(string roleId);
    List<Role> GetAllRoles();
    List<Role> GetRolesByAdminId(string adminId);
    Role UpdateRoleById(string roleId, RoleInfo roleInfo);
    bool DeleteRoleById(string roleId);
    bool AssignRoleToAdmin(string adminId, string roleId);
    bool RemoveRoleFromAdmin(string adminId, string roleId);
}