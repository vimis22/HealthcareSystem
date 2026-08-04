using Notification.Models;

namespace Notification.Interfaces;

public interface INotificationService
{
    Models.Notification CreateNotification(string userId, NotificationInfo notificationInfo);
    Models.Notification GetNotificationById(string notificationId);
    List<Models.Notification> GetNotificationsByUserId(string userId);
    bool MarkAsRead(string notificationId);
    bool DeleteNotificationById(string notificationId);
}
