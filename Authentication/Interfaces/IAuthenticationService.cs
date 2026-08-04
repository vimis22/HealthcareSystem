using Authentication.Models;

namespace Authentication.Interfaces;

public interface IAuthenticationService
{
    AuthenticationResult AuthenticateUserByEmail(string email, string password);
    bool ChangePasswordByUserId(string userId, string currentPassword, string newPassword);
}