using Notification.Interfaces;
using Notification.Models;

namespace Notification.Services;

public class NotificationService : INotificationService
{
    public Models.Notification CreateNotification(string userId, NotificationInfo notificationInfo)
    {
        throw new NotImplementedException();
    }

    public Models.Notification GetNotificationById(string notificationId)
    {
        throw new NotImplementedException();
    }

    public List<Models.Notification> GetNotificationsByUserId(string userId)
    {
        throw new NotImplementedException();
    }

    public bool MarkAsRead(string notificationId)
    {
        throw new NotImplementedException();
    }

    public bool DeleteNotificationById(string notificationId)
    {
        throw new NotImplementedException();
    }
}
