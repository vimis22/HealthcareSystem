using Authentication.Interfaces;
using Authentication.Models;
using Microsoft.EntityFrameworkCore;

namespace DataManager.Services.Authentication;

public class RoleService : IRoleService
{
    private readonly AppDbContext _db;

    public RoleService(AppDbContext db)
    {
        _db = db;
    }

    public Role CreateRole(RoleInfo roleInfo)
    {
        var role = new Role { Id = Guid.NewGuid().ToString(), Name = roleInfo.Name };
        _db.Roles.Add(role);
        _db.SaveChanges();
        return role;
    }

    public Role GetRoleById(string roleId)
    {
        return _db.Roles.FirstOrDefault(r => r.Id == roleId);
    }

    public List<Role> GetAllRoles()
    {
        return _db.Roles.ToList();
    }

    public List<Role> GetRolesByAdminId(string adminId)
    {
        var roleIds = _db.Set<Dictionary<string, object>>("AdminRoles")
            .Where(ar => EF.Property<string>(ar, "AdminId") == adminId)
            .Select(ar => EF.Property<string>(ar, "RoleId"))
            .ToList();
        return _db.Roles.Where(r => roleIds.Contains(r.Id)).ToList();
    }

    public Role UpdateRoleById(string roleId, RoleInfo roleInfo)
    {
        var role = _db.Roles.FirstOrDefault(r => r.Id == roleId);
        if (role == null) return null;
        role.Name = roleInfo.Name;
        _db.SaveChanges();
        return role;
    }

    public bool DeleteRoleById(string roleId)
    {
        var role = _db.Roles.FirstOrDefault(r => r.Id == roleId);
        if (role == null) return false;
        _db.Roles.Remove(role);
        _db.SaveChanges();
        return true;
    }

    public bool AssignRoleToAdmin(string adminId, string roleId)
    {
        var admin = _db.Admins.FirstOrDefault(a => a.Id == adminId);
        var role = _db.Roles.FirstOrDefault(r => r.Id == roleId);
        if (admin == null || role == null) return false;
        _db.Set<Dictionary<string, object>>("AdminRoles").Add(new Dictionary<string, object>
        {
            { "AdminId", adminId },
            { "RoleId", roleId }
        });
        _db.SaveChanges();
        return true;
    }

    public bool RemoveRoleFromAdmin(string adminId, string roleId)
    {
        var entry = _db.Set<Dictionary<string, object>>("AdminRoles")
            .FirstOrDefault(ar => EF.Property<string>(ar, "AdminId") == adminId && EF.Property<string>(ar, "RoleId") == roleId);
        if (entry == null) return false;
        _db.Set<Dictionary<string, object>>("AdminRoles").Remove(entry);
        _db.SaveChanges();
        return true;
    }
}
