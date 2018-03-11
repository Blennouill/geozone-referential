using GeoZoneReferential.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GeoZoneReferential.Domain.Models
{
    /// <summary>
    /// Design to describe parameter of research of a city
    /// </summary>
    public class CityResearchModel : ResearchModel<City>
    {
        public string Wording { get; set; }
        public string PostalCode { get; set; }

        public CityResearchModel() : base() { }

        public Expression<Func<City, bool>> Build()
        {
            if (!string.IsNullOrEmpty(Wording))
                base.Add(city => city.Wording.ToUpper(CultureInfo.InvariantCulture).Contains(Wording.ToUpper(CultureInfo.InvariantCulture)));

            if (!string.IsNullOrEmpty(PostalCode))
                base.Add(city => city.Wording.ToUpper(CultureInfo.InvariantCulture).Contains(Wording.ToUpper(CultureInfo.InvariantCulture)));

            return this.CurrentExpressions;
        }
    }
}
