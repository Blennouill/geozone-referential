using GeoZoneReferential.Domain.Shared.Interfaces;
using System;

namespace GeoZoneReferential.Domain.Shared.Models
{
    /// <summary>
    /// Represent an information to return to the user
    /// </summary>
    public class Notification : INotification
    {
        public Guid Id { get; set; }

        public string Value { get; set; }

        public Notification(string value)
        {
            Id = Guid.NewGuid();
            Value = value;
        }
    }
}