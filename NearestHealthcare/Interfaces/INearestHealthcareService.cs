using HealthcareProvider.Models;
using NearestHealthcare.Models;

namespace NearestHealthcare.Interfaces;

public interface INearestHealthcareService
{
    Clinic GetNearestClinicByCoordinates(LocationInfo locationInfo);
    List<Clinic> GetNearestClinicsByCoordinates(LocationInfo locationInfo);
    Clinic GetNearestClinicByAddress(string streetname, string cityId);
    List<Clinic> GetNearestClinicsByAddress(string streetname, string cityId);
}
