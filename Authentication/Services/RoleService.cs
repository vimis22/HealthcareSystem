using Authentication.Interfaces;
using Authentication.Models;

namespace Authentication.Services;

public class RoleService : IRoleService
{
    public Role CreateRole(RoleInfo roleInfo)
    {
        throw new NotImplementedException();
    }

    public Role GetRoleById(string roleId)
    {
        throw new NotImplementedException();
    }

    public List<Role> GetAllRoles()
    {
        throw new NotImplementedException();
    }

    public List<Role> GetRolesByAdminId(string adminId)
    {
        throw new NotImplementedException();
    }

    public Role UpdateRoleById(string roleId, RoleInfo roleInfo)
    {
        throw new NotImplementedException();
    }

    public bool DeleteRoleById(string roleId)
    {
        throw new NotImplementedException();
    }

    public bool AssignRoleToAdmin(string adminId, string roleId)
    {
        throw new NotImplementedException();
    }

    public bool RemoveRoleFromAdmin(string adminId, string roleId)
    {
        throw new NotImplementedException();
    }
}