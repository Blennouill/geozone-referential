using GeoZoneReferential.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeoZoneReferential.Domain.Entities
{
    /// <summary>
    /// Represent a country
    /// </summary>
    public class Country : IEntity, IEntityHasParent
    {
        public int Id { get; set; }
        /// <summary>
        /// Name of the country
        /// </summary>
        public string Wording { get; set; }

        /// <summary>
        /// The associate ISO3166-A2 code
        /// </summary>
        public string ISO3166A2Code { get; set; }

        /// <summary>
        /// The Id of the parent
        /// </summary>
        public int ParentId { get => CountryOwnerId; }

        /// <summary>
        /// The Id of the parent
        /// </summary>
        public int CountryOwnerId { get; set; }

        /// <summary>
        /// THe parent
        /// </summary>
        public virtual Country CountryOwner { get; set; }
    }
}
