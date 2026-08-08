using Microsoft.EntityFrameworkCore;
using User.Interfaces;
using User.Models;

namespace DataManager.Services.User;

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
        return _db.Telephones
            .Where(t => _db.Set<Dictionary<string, object>>("UserTelephones")
                .Any(ut => (string)ut["TelephoneId"] == t.Id && (string)ut["UserId"] == userId))
            .ToList();
    }

    public Telephone UpdateTelephoneById(string telephoneId, TelephoneInfo telephoneInfo)
    {
        var telephone = _db.Telephones.FirstOrDefault(t => t.Id == telephoneId);
        if (telephone == null) return null;
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
        var user = _db.Users.FirstOrDefault(u => u.Id == userId);
        var telephone = _db.Telephones.FirstOrDefault(t => t.Id == telephoneId);
        if (user == null || telephone == null) return false;
        _db.Set<Dictionary<string, object>>("UserTelephones").Add(new Dictionary<string, object>
        {
            { "UserId", userId },
            { "TelephoneId", telephoneId }
        });
        _db.SaveChanges();
        return true;
    }

    public bool RemoveTelephoneFromUser(string userId, string telephoneId)
    {
        var entry = _db.Set<Dictionary<string, object>>("UserTelephones")
            .FirstOrDefault(ut => EF.Property<string>(ut, "UserId") == userId && EF.Property<string>(ut, "TelephoneId") == telephoneId);
        if (entry == null) return false;
        _db.Set<Dictionary<string, object>>("UserTelephones").Remove(entry);
        _db.SaveChanges();
        return true;
    }
}
