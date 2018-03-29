using GeoZoneReferential.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeoZoneReferential.Domain.Entities
{
    /// <summary>
    /// Represent a city
    /// </summary>
    public class City : IEntity, IIsReliability
    {
        /// <summary>
        /// <see cref="IEntity.Id"/>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Postal code of the city
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Name of the city
        /// </summary>
        public string Wording { get; set; }

        /// <summary>
        /// Name of the city according to the S42 format
        /// </summary>
        /// <remarks>See http://www.rnvp-internationale.com/norme-postale/S42-norme-adresse-internationale.php </remarks>
        public string WordingS42Standard { get; set; }

        /// <summary>
        /// Complementary name (like old city name for example)
        /// </summary>
        public string ComplementaryWording { get; set; }

        /// <summary>
        /// Is used to define the last date of reliabiliting
        /// </summary>
        public DateTime LastReliabilitingDate { get; set; }

        /// <summary>
        /// The id of the country owner's.
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// The country owner's.
        /// </summary>
        public virtual Country Country { get; set; }

        /// <summary>
        /// Define the id of the administrative zone of the city.
        /// </summary>
        public int AdministrativeZoneId { get; set; }

        /// <summary>
        /// Define the administrative zone of the city.
        /// </summary>
        public AdministrativeZone AdministrativeZone { get; set; }
    }
}
