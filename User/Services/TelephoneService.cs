using DataManager;
using Microsoft.EntityFrameworkCore;
using User.Interfaces;
using User.Models;

namespace User.Services;

public class TelephoneService : ITelephoneService
{
    private readonly AppDbContext _db;

    public TelephoneService(AppDbContext db)
    {
        _db = db;
    }
    public Telephone CreateTelephone(TelephoneInfo telephoneInfo)
    {
        var telephone = new Telephone
        {
            Id = Guid.NewGuid().ToString(),
            Countrycode = telephoneInfo.Countrycode,
            Phonenumber = telephoneInfo.Phonenumber
        };
        _db.Telephones.Add(telephone);
        _db.SaveChanges();
        return telephone;
    }

    public Telephone GetTelephoneById(string telephoneId)
    {
        return _db.Telephones.FirstOrDefault(t => t.Id == telephoneId);
    }

    public Telephone GetTelephoneByFullNumber(string countrycode, string phonenumber)
    {
        return _db.Telephones.FirstOrDefault(t => t.Countrycode == countrycode && t.Phonenumber == phonenumber);
    }

    public List<Telephone> GetTelephonesByCountrycode(string countrycode)
    {
        return _db.Telephones.Where(t => t.Countrycode == countrycode).ToList();
    }

    public List<Telephone> GetTelephonesByUserId(string userId)
    {
        var user = _db.Users
            .Include("Telephones")
            .FirstOrDefault(u => u.Id == userId);
        return user?.Telephones ?? new List<Telephone>();
    }

    public Telephone UpdateTelephoneById(string telephoneId, TelephoneInfo telephoneInfo)
    {
        var telephone = _db.Telephones.FirstOrDefault(t => t.Id == telephoneId);
        telephone.Phonenumber = telephoneInfo.Phonenumber;
        telephone.Countrycode = telephoneInfo.Countrycode;
        _db.SaveChanges();
        return telephone;
    }

    public bool DeleteTelephoneById(string telephoneId)
    {
        var telephone = _db.Telephones.FirstOrDefault(t => t.Id == telephoneId);
        if (telephone == null) return false;
        _db.Telephones.Remove(telephone);
        _db.SaveChanges();
        return true;
    }

    public bool AssignTelephoneToUser(string userId, string telephoneId)
    {
        var user = _db.Users
            .Include("Telephones")
            .FirstOrDefault(u => u.Id == userId);
        var telephone = _db.Telephones.FirstOrDefault(t => t.Id == telephoneId);
        if (user == null || telephone == null) return false;
        user.Telephones.Add(telephone);
        _db.SaveChanges();
        return true;
    }

    public bool RemoveTelephoneFromUser(string userId, string telephoneId)
    {
        var user = _db.Users
            .Include("Telephones")
            .FirstOrDefault(u => u.Id == userId);
        var telephone = user?.Telephones.FirstOrDefault(t => t.Id == telephoneId);
        if (telephone == null) return false;
        user.Telephones.Remove(telephone);
        _db.SaveChanges();
        return true;
    }
}
