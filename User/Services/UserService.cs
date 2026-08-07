using DataManager;
using Microsoft.EntityFrameworkCore;
using User.Interfaces;
using User.Models;

namespace User.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _db;

    public UserService(AppDbContext db)
    {
        _db = db;
    }
    public Models.User CreateUser(UserInfo userInfo)
    {
        var user = new Models.User
        {
            Id = Guid.NewGuid().ToString(),
            Firstname = userInfo.Firstname,
            Middlename = userInfo.Middlename,
            Lastname = userInfo.Lastname,
            Streetname = userInfo.Streetname,
            CityId = userInfo.CityId,
            Password = userInfo.Password,
        };
        _db.Users.Add(user);
        _db.SaveChanges();
        return user;
    }

    public Models.User GetUserById(string userId)
    {
        return _db.Users.FirstOrDefault(u => u.Id == userId);
    }

    public List<Models.User> GetUsersByFullName(string firstname, string middlename, string lastname)
    {
        return _db.Users.Where(u => u.Firstname == firstname && u.Middlename == middlename && u.Lastname == lastname).ToList();
    }

    public List<Models.User> GetUsersByFirstname(string firstname)
    {
        return _db.Users.Where(u => u.Firstname == firstname).ToList();
    }

    public List<Models.User> GetUsersByMiddlename(string middlename)
    {
        return _db.Users.Where(u => u.Middlename == middlename).ToList();
    }

    public List<Models.User> GetUsersByLastname(string lastname)
    {
        return _db.Users.Where(u => u.Lastname == lastname).ToList();
    }

    public List<Models.User> GetUsersByStreetname(string streetname)
    {
        return _db.Users.Where(u => u.Streetname == streetname).ToList();
    }

    public List<Models.User> GetUsersByCityId(string cityId)
    {
        return _db.Users.Where(u => u.CityId == cityId).ToList();
    }

    public Models.User UpdateUserById(string userId, UserInfo userInfo)
    {
        var user = _db.Users.FirstOrDefault(u => u.Id == userId);
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