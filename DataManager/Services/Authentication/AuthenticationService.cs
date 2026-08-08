using Authentication.Interfaces;
using Authentication.Models;

namespace DataManager.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly AppDbContext _db;

    public AuthenticationService(AppDbContext db)
    {
        _db = db;
    }

    public AuthenticationResult AuthenticateUserByEmail(string email, string password)
    {
        var emailRecord = _db.Emails.FirstOrDefault(e => e.Name == email);
        if (emailRecord == null)
            return new AuthenticationResult { Success = false };

        var user = _db.Users.FirstOrDefault(u => u.Id == emailRecord.UserId);
        if (user == null || user.Password != password)
            return new AuthenticationResult { Success = false };

        return new AuthenticationResult
        {
            Success = true,
            UserId = user.Id,
            Token = Guid.NewGuid().ToString()
        };
    }

    public bool ChangePasswordByUserId(string userId, string currentPassword, string newPassword)
    {
        var user = _db.Users.FirstOrDefault(u => u.Id == userId);
        if (user == null || user.Password != currentPassword) return false;
        user.Password = newPassword;
        _db.SaveChanges();
        return true;
    }
}
