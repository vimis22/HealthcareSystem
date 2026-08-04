using User.Models;

namespace User.Interfaces;

public interface IUserService
{
    Models.User CreateUser(UserInfo userInfo);
    Models.User GetUserById(string userId);
    List<Models.User> GetUsersByFullName(string firstname, string middlename, string lastname);
    List<Models.User> GetUsersByFirstname(string firstname);
    List<Models.User> GetUsersByMiddlename(string middlename);
    List<Models.User> GetUsersByLastname(string lastname);
    List<Models.User> GetUsersByStreetname(string streetname);
    List<Models.User> GetUsersByCityId(string cityId);
    Models.User UpdateUserById(string userId, UserInfo userInfo);
    bool DeleteUserById(string userId);
}