using HealthcareProvider.Models;

namespace HealthcareProvider.Interfaces;

public interface IClinicService
{
    Clinic CreateClinic(ClinicInfo clinicInfo);
    Clinic GetClinicById(string clinicId);
    List<Clinic> GetClinicsByName(string name);
    List<Clinic> GetClinicsByCityId(string cityId);
    List<Clinic> GetClinicsByStreetname(string streetname);
    List<Clinic> GetClinicsByEmail(string email);
    List<Clinic> GetClinicsByTelephone(string telephone);
    List<Clinic> GetClinicsByOpeningtime(DateTime openingtime);
    List<Clinic> GetClinicsByClosingtime(DateTime closingtime);
    Clinic UpdateClinicById(string clinicId, ClinicInfo clinicInfo);
    bool DeleteClinicById(string clinicId);
}