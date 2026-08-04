namespace HealthcareProvider.Models;

public class ClinicInfo
{
    public string Name { get; set; }
    public string Streetname { get; set; }
    public string CityId { get; set; }
    public DateTime Openingtime { get; set; }
    public DateTime Closingtime { get; set; }
    public string Telephone { get; set; }
    public string Email { get; set; }
}