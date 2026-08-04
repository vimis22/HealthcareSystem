using User.Interfaces;
using User.Models;

namespace User.Services;

public class UserService : IUserService
{
    public Models.User CreateUser(UserInfo userInfo)
    {
        throw new NotImplementedException();
    }

    public Models.User GetUserById(string userId)
    {
        throw new NotImplementedException();
    }

    public List<Models.User> GetUsersByFullName(string firstname, string middlename, string lastname)
    {
        throw new NotImplementedException();
    }

    public List<Models.User> GetUsersByFirstname(string firstname)
    {
        throw new NotImplementedException();
    }

    public List<Models.User> GetUsersByMiddlename(string middlename)
    {
        throw new NotImplementedException();
    }

    public List<Models.User> GetUsersByLastname(string lastname)
    {
        throw new NotImplementedException();
    }

    public List<Models.User> GetUsersByStreetname(string streetname)
    {
        throw new NotImplementedException();
    }

    public List<Models.User> GetUsersByCityId(string cityId)
    {
        throw new NotImplementedException();
    }

    public Models.User UpdateUserById(string userId, UserInfo userInfo)
    {
        throw new NotImplementedException();
    }

    public bool DeleteUserById(string userId)
    {
        throw new NotImplementedException();
    }
}