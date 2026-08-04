using HealthcareProvider.Interfaces;
using HealthcareProvider.Models;

namespace HealthcareProvider.Services;

public class ClinicService: IClinicService
{
    public Clinic CreateClinic(ClinicInfo clinicInfo)
    {
        throw new NotImplementedException();
    }

    public Clinic GetClinicById(string clinicId)
    {
        throw new NotImplementedException();
    }

    public List<Clinic> GetClinicsByName(string name)
    {
        throw new NotImplementedException();
    }

    public List<Clinic> GetClinicsByCityId(string cityId)
    {
        throw new NotImplementedException();
    }

    public List<Clinic> GetClinicsByStreetname(string streetname)
    {
        throw new NotImplementedException();
    }

    public List<Clinic> GetClinicsByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public List<Clinic> GetClinicsByTelephone(string telephone)
    {
        throw new NotImplementedException();
    }

    public List<Clinic> GetClinicsByOpeningtime(DateTime openingtime)
    {
        throw new NotImplementedException();
    }

    public List<Clinic> GetClinicsByClosingtime(DateTime closingtime)
    {
        throw new NotImplementedException();
    }

    public Clinic UpdateClinicById(string clinicId, ClinicInfo clinicInfo)
    {
        throw new NotImplementedException();
    }

    public bool DeleteClinicById(string clinicId)
    {
        throw new NotImplementedException();
    }
}