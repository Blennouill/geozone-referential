using GeoZoneReferential.Domain.Shared.Interfaces;
using System.Collections.Generic;

namespace GeoZoneReferential.Domain.Interfaces
{
    /// <summary>
    /// Is used to manage notification trough the application
    /// </summary>
    public interface INotificationService
    {
        /// <summary>
        /// Is used to add a new notification in the current operation
        /// </summary>
        /// <param name="message">the notification to add</param>
        void AddNotification(INotification notification);

        /// <summary>
        /// Is used to return all the notification from the current operation
        /// </summary>
        IReadOnlyList<INotification> GetNotifications();
    }
}