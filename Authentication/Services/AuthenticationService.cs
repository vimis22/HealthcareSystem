using Authentication.Interfaces;
using Authentication.Models;

namespace Authentication.Services;

public class AuthenticationService : IAuthenticationService
{
    public AuthenticationResult AuthenticateUserByEmail(string email, string password)
    {
        throw new NotImplementedException();
    }

    public bool ChangePasswordByUserId(string userId, string currentPassword, string newPassword)
    {
        throw new NotImplementedException();
    }
}