namespace HealthCard.Models;

public class HealthCard
{
    public string Id { get; set; }
    public string Cpr { get; set; }
    public string Sikringsgruppe { get; set; }
    public DateTime ValidFrom { get; set; }
    public string ClientId { get; set; }
    public string ClinicId { get; set; }
}
