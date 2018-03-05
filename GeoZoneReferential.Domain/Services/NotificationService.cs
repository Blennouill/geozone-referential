using GeoZoneReferential.Domain.Interfaces;
using GeoZoneReferential.Domain.Shared.Interfaces;
using System.Collections.Generic;

namespace GeoZoneReferential.Core.Services
{
    /// <summary>
    /// Is used to manage notification trough the application
    /// </summary>
    public class NotificationService : INotificationService
    {
        private List<INotification> _notifications;

        public NotificationService()
        {
            _notifications = new List<INotification>();
        }

        /// <summary>
        /// Is used to return all the notification from the current operation
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<INotification> GetNotifications()
        {
            return _notifications.AsReadOnly();
        }

        /// <summary>
        /// Is used to add a new notification in the current operation
        /// </summary>
        /// <param name="message">the notification to add</param>
        public void AddNotification(INotification notification)
        {
            _notifications.Add(notification);
        }
    }
}