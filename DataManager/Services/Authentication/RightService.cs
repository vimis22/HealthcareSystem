using Authentication.Interfaces;
using Authentication.Models;
using Microsoft.EntityFrameworkCore;

namespace DataManager.Services.Authentication;

public class RightService : IRightService
{
    private readonly AppDbContext _db;

    public RightService(AppDbContext db)
    {
        _db = db;
    }

    public Right CreateRight(RightInfo rightInfo)
    {
        var right = new Right { Id = Guid.NewGuid().ToString(), Name = rightInfo.Name };
        _db.Rights.Add(right);
        _db.SaveChanges();
        return right;
    }

    public Right GetRightById(string rightId)
    {
        return _db.Rights.FirstOrDefault(r => r.Id == rightId);
    }

    public List<Right> GetAllRights()
    {
        return _db.Rights.ToList();
    }

    public List<Right> GetRightsByRoleId(string roleId)
    {
        var rightIds = _db.Set<Dictionary<string, object>>("RoleRights")
            .Where(rr => EF.Property<string>(rr, "RoleId") == roleId)
            .Select(rr => EF.Property<string>(rr, "RightId"))
            .ToList();
        return _db.Rights.Where(r => rightIds.Contains(r.Id)).ToList();
    }

    public List<Right> GetRightsByAdminId(string adminId)
    {
        var roleIds = _db.Set<Dictionary<string, object>>("AdminRoles")
            .Where(ar => EF.Property<string>(ar, "AdminId") == adminId)
            .Select(ar => EF.Property<string>(ar, "RoleId"))
            .ToList();
        var rightIds = _db.Set<Dictionary<string, object>>("RoleRights")
            .Where(rr => roleIds.Contains(EF.Property<string>(rr, "RoleId")))
            .Select(rr => EF.Property<string>(rr, "RightId"))
            .ToList();
        return _db.Rights.Where(r => rightIds.Contains(r.Id)).DistinctBy(r => r.Id).ToList();
    }

    public Right UpdateRightById(string rightId, RightInfo rightInfo)
    {
        var right = _db.Rights.FirstOrDefault(r => r.Id == rightId);
        if (right == null) return null;
        right.Name = rightInfo.Name;
        _db.SaveChanges();
        return right;
    }

    public bool DeleteRightById(string rightId)
    {
        var right = _db.Rights.FirstOrDefault(r => r.Id == rightId);
        if (right == null) return false;
        _db.Rights.Remove(right);
        _db.SaveChanges();
        return true;
    }

    public bool AssignRightToRole(string roleId, string rightId)
    {
        var role = _db.Roles.FirstOrDefault(r => r.Id == roleId);
        var right = _db.Rights.FirstOrDefault(r => r.Id == rightId);
        if (role == null || right == null) return false;
        _db.Set<Dictionary<string, object>>("RoleRights").Add(new Dictionary<string, object>
        {
            { "RoleId", roleId },
            { "RightId", rightId }
        });
        _db.SaveChanges();
        return true;
    }

    public bool RemoveRightFromRole(string roleId, string rightId)
    {
        var entry = _db.Set<Dictionary<string, object>>("RoleRights")
            .FirstOrDefault(rr => EF.Property<string>(rr, "RoleId") == roleId && EF.Property<string>(rr, "RightId") == rightId);
        if (entry == null) return false;
        _db.Set<Dictionary<string, object>>("RoleRights").Remove(entry);
        _db.SaveChanges();
        return true;
    }
}
