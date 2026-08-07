namespace User.Models;

public class User
{
    public string Id { get; set; }
    public string Firstname { get; set; }
    public string Middlename { get; set; }
    public string Lastname { get; set; }
    public string Streetname { get; set; }
    public string CityId { get; set; }
    public string Password { get; set; }
    public List<Telephone> Telephones { get; set; } = new();
    public List<Email> Emails { get; set; } = new();
}