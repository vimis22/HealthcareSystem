using User.Models;

namespace User.Interfaces;

public interface ITelephoneService
{
    Telephone CreateTelephone(TelephoneInfo telephoneInfo);
    Telephone GetTelephoneById(string telephoneId);
    Telephone GetTelephoneByFullNumber(string countrycode, string phonenumber);
    List<Telephone> GetTelephonesByCountrycode(string countrycode);
    List<Telephone> GetTelephonesByUserId(string userId);
    Telephone UpdateTelephoneById(string telephoneId, TelephoneInfo telephoneInfo);
    bool DeleteTelephoneById(string telephoneId);
    bool AssignTelephoneToUser(string userId, string telephoneId);
    bool RemoveTelephoneFromUser(string userId, string telephoneId);
}
