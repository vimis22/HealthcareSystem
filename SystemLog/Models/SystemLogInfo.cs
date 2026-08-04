namespace SystemLog.Models;

public class SystemLogInfo
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public bool Success { get; set; }
    public bool Error { get; set; }
}