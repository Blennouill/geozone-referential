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
        public string Wording { get; set; }
        public string ISO3166A2Code { get; set; }
        
        public int ParentId { get => CountryOwnerId; }

        public int CountryOwnerId { get; set; }
        public virtual Country CountryOwner { get; set; }
    }
}
