using GeoZoneReferential.Domain.Entities;
using System;
using System.Globalization;
using System.Linq.Expressions;

namespace GeoZoneReferential.Interface.Models
{
    /// <summary>
    /// Design to describe parameter of research of a city
    /// </summary>
    public class CityResearchModel : ResearchModel<City>
    {
        public string Wording { get; set; }
        public string PostalCode { get; set; }

        public CityResearchModel() : base() { }

        /// <summary>
        /// <see cref="ResearchModel{T}.Build"/>
        /// </summary>
        public override Expression<Func<City, bool>> Build()
        {
            if (!string.IsNullOrEmpty(Wording))
                base.Add(city => city.Wording.ToUpper(CultureInfo.InvariantCulture).Contains(Wording.ToUpper(CultureInfo.InvariantCulture)));

            if (!string.IsNullOrEmpty(PostalCode))
                base.Add(city => city.Wording.ToUpper(CultureInfo.InvariantCulture).Contains(Wording.ToUpper(CultureInfo.InvariantCulture)));

            return this.CurrentExpressions;
        }
    }
}
