using Notification.Interfaces;
using Notification.Models;

namespace DataManager.Services.Notification;

public class NotificationService : INotificationService
{
    private readonly AppDbContext _db;

    public NotificationService(AppDbContext db)
    {
        _db = db;
    }

    public global::Notification.Models.Notification CreateNotification(string userId, NotificationInfo notificationInfo)
    {
        var notification = new global::Notification.Models.Notification
        {
            Id = Guid.NewGuid().ToString(),
            Title = notificationInfo.Title,
            Message = notificationInfo.Message,
            CreatedAt = DateTime.UtcNow,
            IsRead = false,
            UserId = userId
        };
        _db.Notifications.Add(notification);
        _db.SaveChanges();
        return notification;
    }

    public global::Notification.Models.Notification GetNotificationById(string notificationId)
    {
        return _db.Notifications.FirstOrDefault(n => n.Id == notificationId);
    }

    public List<global::Notification.Models.Notification> GetNotificationsByUserId(string userId)
    {
        return _db.Notifications.Where(n => n.UserId == userId).ToList();
    }

    public bool MarkAsRead(string notificationId)
    {
        var notification = _db.Notifications.FirstOrDefault(n => n.Id == notificationId);
        if (notification == null) return false;
        notification.IsRead = true;
        _db.SaveChanges();
        return true;
    }

    public bool DeleteNotificationById(string notificationId)
    {
        var notification = _db.Notifications.FirstOrDefault(n => n.Id == notificationId);
        if (notification == null) return false;
        _db.Notifications.Remove(notification);
        _db.SaveChanges();
        return true;
    }
}
