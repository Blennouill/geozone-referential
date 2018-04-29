using System;

namespace GeoZoneReferential.Domain.Entities.Interfaces
{
    /// <summary>
    /// Is used to describe information about reliabiliting
    /// </summary>
    public interface IIsReliability
    {
        /// <summary>
        /// Describe the date of last reliabiliting
        /// </summary>
        DateTime? LastReliabilitingDate { get; set; }
    }
}