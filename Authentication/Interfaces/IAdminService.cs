using Authentication.Models;
using User.Models;

namespace Authentication.Interfaces;

public interface IAdminService
{
    Admin CreateAdmin(UserInfo userInfo);
    Admin GetAdminById(string adminId);
    List<Admin> GetAllAdmins();
    bool DeleteAdminById(string adminId);
}