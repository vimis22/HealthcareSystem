using HealthcareProvider.Models;

namespace HealthcareProvider.Interfaces;

public interface ICityService
{
    City CreateCity(CityInfo cityInfo);
    City GetCityById(string cityId);
    List<City> GetCitiesByPostalcode(string postalcode);
    List<City> GetCitiesByRegion(string region);
    List<City> GetCitiesByCountry(string country);
    City UpdateCityById(string cityId, CityInfo cityInfo);
    bool DeleteCityById(string cityId);
}
