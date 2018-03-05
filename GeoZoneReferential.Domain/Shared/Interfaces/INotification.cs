using System;

namespace GeoZoneReferential.Domain.Shared.Interfaces
{
    /// <summary>
    /// Is used to define a notification which is transmitted through the logic
    /// </summary>
    public interface INotification
    {
        Guid Id { get; set; }
        string Value { get; set; }
    }
}