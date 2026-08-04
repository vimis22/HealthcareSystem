namespace Notification.Models;

public class Notification
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsRead { get; set; }
    public string UserId { get; set; }
}
