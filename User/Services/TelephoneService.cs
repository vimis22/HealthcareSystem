using User.Interfaces;
using User.Models;

namespace User.Services;

public class TelephoneService : ITelephoneService
{
    public Telephone CreateTelephone(TelephoneInfo telephoneInfo)
    {
        throw new NotImplementedException();
    }

    public Telephone GetTelephoneById(string telephoneId)
    {
        throw new NotImplementedException();
    }

    public Telephone GetTelephoneByFullNumber(string countrycode, string phonenumber)
    {
        throw new NotImplementedException();
    }

    public List<Telephone> GetTelephonesByCountrycode(string countrycode)
    {
        throw new NotImplementedException();
    }

    public List<Telephone> GetTelephonesByUserId(string userId)
    {
        throw new NotImplementedException();
    }

    public Telephone UpdateTelephoneById(string telephoneId, TelephoneInfo telephoneInfo)
    {
        throw new NotImplementedException();
    }

    public bool DeleteTelephoneById(string telephoneId)
    {
        throw new NotImplementedException();
    }

    public bool AssignTelephoneToUser(string userId, string telephoneId)
    {
        throw new NotImplementedException();
    }

    public bool RemoveTelephoneFromUser(string userId, string telephoneId)
    {
        throw new NotImplementedException();
    }
}
