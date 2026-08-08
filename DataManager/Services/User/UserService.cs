using Microsoft.EntityFrameworkCore;
using User.Interfaces;
using User.Models;

namespace DataManager.Services.User;

public class UserService : IUserService
{
    private readonly AppDbContext _db;

    public UserService(AppDbContext db)
    {
        _db = db;
    }

    public global::User.Models.User CreateUser(UserInfo userInfo)
    {
        var user = new global::User.Models.User
        {
            Id = Guid.NewGuid().ToString(),
            Firstname = userInfo.Firstname,
            Middlename = userInfo.Middlename,
            Lastname = userInfo.Lastname,
            Streetname = userInfo.Streetname,
            CityId = userInfo.CityId,
            Password = userInfo.Password
        };
        _db.Users.Add(user);
        _db.SaveChanges();
        return user;
    }

    public global::User.Models.User GetUserById(string userId)
    {
        return _db.Users.FirstOrDefault(u => u.Id == userId);
    }

    public List<global::User.Models.User> GetUsersByFullName(string firstname, string middlename, string lastname)
    {
        return _db.Users.Where(u => u.Firstname == firstname && u.Middlename == middlename && u.Lastname == lastname).ToList();
    }

    public List<global::User.Models.User> GetUsersByFirstname(string firstname)
    {
        return _db.Users.Where(u => u.Firstname == firstname).ToList();
    }

    public List<global::User.Models.User> GetUsersByMiddlename(string middlename)
    {
        return _db.Users.Where(u => u.Middlename == middlename).ToList();
    }

    public List<global::User.Models.User> GetUsersByLastname(string lastname)
    {
        return _db.Users.Where(u => u.Lastname == lastname).ToList();
    }

    public List<global::User.Models.User> GetUsersByStreetname(string streetname)
    {
        return _db.Users.Where(u => u.Streetname == streetname).ToList();
    }

    public List<global::User.Models.User> GetUsersByCityId(string cityId)
    {
        return _db.Users.Where(u => u.CityId == cityId).ToList();
    }

    public global::User.Models.User UpdateUserById(string userId, UserInfo userInfo)
    {
        var user = _db.Users.FirstOrDefault(u => u.Id == userId);
        if (user == null) return null;
        user.Firstname = userInfo.Firstname;
        user.Middlename = userInfo.Middlename;
        user.Lastname = userInfo.Lastname;
        user.Streetname = userInfo.Streetname;
        user.CityId = userInfo.CityId;
        _db.SaveChanges();
        return user;
    }

    public bool DeleteUserById(string userId)
    {
        var user = _db.Users.FirstOrDefault(u => u.Id == userId);
        if (user == null) return false;
        _db.Users.Remove(user);
        _db.SaveChanges();
        return true;
    }
}
