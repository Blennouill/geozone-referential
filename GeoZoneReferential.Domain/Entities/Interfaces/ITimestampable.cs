using System;

namespace GeoZoneReferential.Domain.Entities.Interfaces
{
    /// <summary>
    /// To define the timestampabality
    /// </summary>
    public interface ITimestampable
    {
        /// <summary>
        /// Represent an operation date
        /// </summary>
        DateTime OperationDate { get; set; }
    }
}