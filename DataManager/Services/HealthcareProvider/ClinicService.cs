using HealthcareProvider.Interfaces;
using HealthcareProvider.Models;

namespace DataManager.Services.HealthcareProvider;

public class ClinicService : IClinicService
{
    private readonly AppDbContext _db;

    public ClinicService(AppDbContext db)
    {
        _db = db;
    }

    public Clinic CreateClinic(ClinicInfo clinicInfo)
    {
        var clinic = new Clinic
        {
            Id = Guid.NewGuid().ToString(),
            Name = clinicInfo.Name,
            Streetname = clinicInfo.Streetname,
            CityId = clinicInfo.CityId,
            Openingtime = clinicInfo.Openingtime,
            Closingtime = clinicInfo.Closingtime,
            Telephone = clinicInfo.Telephone,
            Email = clinicInfo.Email
        };
        _db.Clinics.Add(clinic);
        _db.SaveChanges();
        return clinic;
    }

    public Clinic GetClinicById(string clinicId)
    {
        return _db.Clinics.FirstOrDefault(c => c.Id == clinicId);
    }

    public List<Clinic> GetClinicsByName(string name)
    {
        return _db.Clinics.Where(c => c.Name == name).ToList();
    }

    public List<Clinic> GetClinicsByCityId(string cityId)
    {
        return _db.Clinics.Where(c => c.CityId == cityId).ToList();
    }

    public List<Clinic> GetClinicsByStreetname(string streetname)
    {
        return _db.Clinics.Where(c => c.Streetname == streetname).ToList();
    }

    public List<Clinic> GetClinicsByEmail(string email)
    {
        return _db.Clinics.Where(c => c.Email == email).ToList();
    }

    public List<Clinic> GetClinicsByTelephone(string telephone)
    {
        return _db.Clinics.Where(c => c.Telephone == telephone).ToList();
    }

    public List<Clinic> GetClinicsByOpeningtime(DateTime openingtime)
    {
        return _db.Clinics.Where(c => c.Openingtime == openingtime).ToList();
    }

    public List<Clinic> GetClinicsByClosingtime(DateTime closingtime)
    {
        return _db.Clinics.Where(c => c.Closingtime == closingtime).ToList();
    }

    public Clinic UpdateClinicById(string clinicId, ClinicInfo clinicInfo)
    {
        var clinic = _db.Clinics.FirstOrDefault(c => c.Id == clinicId);
        if (clinic == null) return null;
        clinic.Name = clinicInfo.Name;
        clinic.Streetname = clinicInfo.Streetname;
        clinic.CityId = clinicInfo.CityId;
        clinic.Openingtime = clinicInfo.Openingtime;
        clinic.Closingtime = clinicInfo.Closingtime;
        clinic.Telephone = clinicInfo.Telephone;
        clinic.Email = clinicInfo.Email;
        _db.SaveChanges();
        return clinic;
    }

    public bool DeleteClinicById(string clinicId)
    {
        var clinic = _db.Clinics.FirstOrDefault(c => c.Id == clinicId);
        if (clinic == null) return false;
        _db.Clinics.Remove(clinic);
        _db.SaveChanges();
        return true;
    }
}
