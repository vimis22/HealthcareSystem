using Microsoft.AspNetCore.Mvc;
using Notification.Interfaces;
using Notification.Models;

namespace MainCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpPost("{userId}")]
    public IActionResult Create(string userId, [FromBody] NotificationInfo info)
    {
        var notification = _notificationService.CreateNotification(userId, info);
        return Ok(notification);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var notification = _notificationService.GetNotificationById(id);
        if (notification == null) return NotFound();
        return Ok(notification);
    }

    [HttpGet("user/{userId}")]
    public IActionResult GetByUserId(string userId)
    {
        return Ok(_notificationService.GetNotificationsByUserId(userId));
    }

    [HttpPatch("{id}/read")]
    public IActionResult MarkAsRead(string id)
    {
        var success = _notificationService.MarkAsRead(id);
        if (!success) return NotFound();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var success = _notificationService.DeleteNotificationById(id);
        if (!success) return NotFound();
        return Ok();
    }
}
