using GeoZoneReferential.Domain.Entities.Interfaces;
using System.Collections.Generic;

namespace GeoZoneReferential.Domain.Entities
{
    /// <summary>
    /// Define an administration level bounded to a country
    /// </summary>
    /// <example>In France, there is 2 commun levels : Region and Department</example>
    public class AdministrativeLevelZone : IEntity
    {
        /// <summary>
        /// <see cref="IEntity.Id"/>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Is used to define the level of deep
        /// </summary>
        public byte Level { get; set; }

        /// <summary>
        /// Name of the level of subdivision
        /// </summary>
        public string Wording { get; set; }

        /// <summary>
        /// The code of the parent country
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// The parent's Country
        /// </summary>
        public virtual Country Country { get; set; }
    }
}