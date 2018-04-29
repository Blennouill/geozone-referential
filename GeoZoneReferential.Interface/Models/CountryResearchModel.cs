using System;
using System.Globalization;
using System.Linq.Expressions;
using GeoZoneReferential.Domain.Entities;

namespace GeoZoneReferential.Interface.Models
{
    /// <summary>
    /// Design to describe parameter of research
    /// </summary>
    public class CountryResearchModel : ResearchModel<Country>
    {
        /// <summary>
        /// <see cref="Country.Wording"/>
        /// </summary>
        public string Wording { get; set; }

        /// <summary>
        /// <see cref="ResearchModel{T}.Build"/>
        /// </summary>
        public override Expression<Func<Country, bool>> Build()
        {
            if (!string.IsNullOrEmpty(Wording))
                base.Add(city => city.Wording.ToUpper(CultureInfo.InvariantCulture).Contains(Wording.ToUpper(CultureInfo.InvariantCulture)));

            return this.CurrentExpressions;
        }
    }
}
