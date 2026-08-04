using Authentication.Interfaces;
using Authentication.Models;
using User.Models;

namespace Authentication.Services;

public class AdminService : IAdminService
{
    public Admin CreateAdmin(UserInfo userInfo)
    {
        throw new NotImplementedException();
    }

    public Admin GetAdminById(string adminId)
    {
        throw new NotImplementedException();
    }

    public List<Admin> GetAllAdmins()
    {
        throw new NotImplementedException();
    }

    public bool DeleteAdminById(string adminId)
    {
        throw new NotImplementedException();
    }
}