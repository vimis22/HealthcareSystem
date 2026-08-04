using HealthcareProvider.Models;
using NearestHealthcare.Interfaces;
using NearestHealthcare.Models;

namespace NearestHealthcare.Services;

public class NearestHealthcareService : INearestHealthcareService
{
    public Clinic GetNearestClinicByCoordinates(LocationInfo locationInfo)
    {
        throw new NotImplementedException();
    }

    public List<Clinic> GetNearestClinicsByCoordinates(LocationInfo locationInfo)
    {
        throw new NotImplementedException();
    }

    public Clinic GetNearestClinicByAddress(string streetname, string cityId)
    {
        throw new NotImplementedException();
    }

    public List<Clinic> GetNearestClinicsByAddress(string streetname, string cityId)
    {
        throw new NotImplementedException();
    }
}
