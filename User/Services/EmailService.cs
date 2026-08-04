using User.Interfaces;
using User.Models;

namespace User.Services;

public class EmailService : IEmailService
{
    public Email CreateEmail(string userId, EmailInfo emailInfo)
    {
        throw new NotImplementedException();
    }

    public Email GetEmailById(string emailId)
    {
        throw new NotImplementedException();
    }

    public List<Email> GetEmailsByUserId(string userId)
    {
        throw new NotImplementedException();
    }

    public Email GetPrimaryEmailByUserId(string userId)
    {
        throw new NotImplementedException();
    }

    public List<Email> GetEmailsByName(string name)
    {
        throw new NotImplementedException();
    }

    public Email UpdateEmailById(string emailId, EmailInfo emailInfo)
    {
        throw new NotImplementedException();
    }

    public bool SetPrimaryEmailForUser(string userId, string emailId)
    {
        throw new NotImplementedException();
    }

    public bool DeleteEmailById(string emailId)
    {
        throw new NotImplementedException();
    }
}
