namespace Coverage.Models;

public class ClientLog
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string Type { get; set; }
    public string ClientId { get; set; }
    public string CaretakerId { get; set; }
    public string CoverageId { get; set; }
}