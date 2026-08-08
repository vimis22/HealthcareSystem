using HealthcareProvider.Interfaces;
using HealthcareProvider.Models;

namespace DataManager.Services.HealthcareProvider;

public class CityService : ICityService
{
    private readonly AppDbContext _db;

    public CityService(AppDbContext db)
    {
        _db = db;
    }

    public City CreateCity(CityInfo cityInfo)
    {
        var city = new City
        {
            Id = Guid.NewGuid().ToString(),
            Postalcode = cityInfo.Postalcode,
            Region = cityInfo.Region,
            Country = cityInfo.Country
        };
        _db.Cities.Add(city);
        _db.SaveChanges();
        return city;
    }

    public City GetCityById(string cityId)
    {
        return _db.Cities.FirstOrDefault(c => c.Id == cityId);
    }

    public List<City> GetCitiesByPostalcode(string postalcode)
    {
        return _db.Cities.Where(c => c.Postalcode == postalcode).ToList();
    }

    public List<City> GetCitiesByRegion(string region)
    {
        return _db.Cities.Where(c => c.Region == region).ToList();
    }

    public List<City> GetCitiesByCountry(string country)
    {
        return _db.Cities.Where(c => c.Country == country).ToList();
    }

    public City UpdateCityById(string cityId, CityInfo cityInfo)
    {
        var city = _db.Cities.FirstOrDefault(c => c.Id == cityId);
        if (city == null) return null;
        city.Postalcode = cityInfo.Postalcode;
        city.Region = cityInfo.Region;
        city.Country = cityInfo.Country;
        _db.SaveChanges();
        return city;
    }

    public bool DeleteCityById(string cityId)
    {
        var city = _db.Cities.FirstOrDefault(c => c.Id == cityId);
        if (city == null) return false;
        _db.Cities.Remove(city);
        _db.SaveChanges();
        return true;
    }
}
