using GeoZoneReferential.Domain.Entities.Interfaces;
using System.Collections.Generic;

namespace GeoZoneReferential.Domain.Entities
{
    /// <summary>
    /// Define an administrative zone
    /// </summary>
    /// <example>In France, there is 2 commun levels : Region and Department</example>
    public class AdministrativeZone : IEntity
    {
        /// <summary>
        /// <see cref="IEntity.Id"/>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The ISO3166-2 code for the bounded zone
        /// </summary>
        public string ISO3166A2Code { get; set; }

        /// <summary>
        /// The ISO3166-2 code for the parent of the bounded zone
        /// </summary>
        public string ISO3166A2ParentCode { get; set; }

        /// <summary>
        /// Name og the zone
        /// </summary>
        public string Wording { get; set; }

        /// <summary>
        /// If of the level of the zone
        /// </summary>
        public int AdministrativeLevelZoneId { get; set; }

        /// <summary>
        /// The level of the zone
        /// </summary>
        public virtual AdministrativeLevelZone AdministrativeLevelZone { get; set; }
    }
}