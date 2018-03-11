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
    }
}
