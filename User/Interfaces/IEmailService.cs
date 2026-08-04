using User.Models;

namespace User.Interfaces;

public interface IEmailService
{
    Email CreateEmail(string userId, EmailInfo emailInfo);
    Email GetEmailById(string emailId);
    List<Email> GetEmailsByUserId(string userId);
    Email GetPrimaryEmailByUserId(string userId);
    List<Email> GetEmailsByName(string name);
    Email UpdateEmailById(string emailId, EmailInfo emailInfo);
    bool SetPrimaryEmailForUser(string userId, string emailId);
    bool DeleteEmailById(string emailId);
}
