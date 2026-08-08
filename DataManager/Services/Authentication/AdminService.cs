using Authentication.Interfaces;
using Authentication.Models;
using User.Models;

namespace DataManager.Services.Authentication;

public class AdminService : IAdminService
{
    private readonly AppDbContext _db;

    public AdminService(AppDbContext db)
    {
        _db = db;
    }

    public Admin CreateAdmin(UserInfo userInfo)
    {
        var admin = new Admin
        {
            Id = Guid.NewGuid().ToString(),
            Firstname = userInfo.Firstname,
            Middlename = userInfo.Middlename,
            Lastname = userInfo.Lastname,
            Streetname = userInfo.Streetname,
            CityId = userInfo.CityId,
            Password = userInfo.Password
        };
        _db.Admins.Add(admin);
        _db.SaveChanges();
        return admin;
    }

    public Admin GetAdminById(string adminId)
    {
        return _db.Admins.FirstOrDefault(a => a.Id == adminId);
    }

    public List<Admin> GetAllAdmins()
    {
        return _db.Admins.ToList();
    }

    public bool DeleteAdminById(string adminId)
    {
        var admin = _db.Admins.FirstOrDefault(a => a.Id == adminId);
        if (admin == null) return false;
        _db.Admins.Remove(admin);
        _db.SaveChanges();
        return true;
    }
}
