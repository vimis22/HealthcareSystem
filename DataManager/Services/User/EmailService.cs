using User.Interfaces;
using User.Models;

namespace DataManager.Services.User;

public class EmailService : IEmailService
{
    private readonly AppDbContext _db;

    public EmailService(AppDbContext db)
    {
        _db = db;
    }

    public Email CreateEmail(string userId, EmailInfo emailInfo)
    {
        var email = new Email
        {
            Id = Guid.NewGuid().ToString(),
            Name = emailInfo.Name,
            IsPrimary = emailInfo.IsPrimary,
            UserId = userId
        };
        _db.Emails.Add(email);
        _db.SaveChanges();
        return email;
    }

    public Email GetEmailById(string emailId)
    {
        return _db.Emails.FirstOrDefault(e => e.Id == emailId);
    }

    public List<Email> GetEmailsByUserId(string userId)
    {
        return _db.Emails.Where(e => e.UserId == userId).ToList();
    }

    public Email GetPrimaryEmailByUserId(string userId)
    {
        return _db.Emails.FirstOrDefault(e => e.UserId == userId && e.IsPrimary);
    }

    public List<Email> GetEmailsByName(string name)
    {
        return _db.Emails.Where(e => e.Name == name).ToList();
    }

    public Email UpdateEmailById(string emailId, EmailInfo emailInfo)
    {
        var email = _db.Emails.FirstOrDefault(e => e.Id == emailId);
        if (email == null) return null;
        email.Name = emailInfo.Name;
        email.IsPrimary = emailInfo.IsPrimary;
        _db.SaveChanges();
        return email;
    }

    public bool SetPrimaryEmailForUser(string userId, string emailId)
    {
        var emails = _db.Emails.Where(e => e.UserId == userId).ToList();
        foreach (var e in emails)
            e.IsPrimary = false;
        var primary = emails.FirstOrDefault(e => e.Id == emailId);
        if (primary == null) return false;
        primary.IsPrimary = true;
        _db.SaveChanges();
        return true;
    }

    public bool DeleteEmailById(string emailId)
    {
        var email = _db.Emails.FirstOrDefault(e => e.Id == emailId);
        if (email == null) return false;
        _db.Emails.Remove(email);
        _db.SaveChanges();
        return true;
    }
}
