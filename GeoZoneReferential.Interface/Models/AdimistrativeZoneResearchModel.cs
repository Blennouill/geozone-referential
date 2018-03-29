using GeoZoneReferential.Domain.Entities;
using System;
using System.Globalization;
using System.Linq.Expressions;

namespace GeoZoneReferential.Interface.Models
{
    /// <summary>
    /// Design to describe parameter of research of an administrative zone
    /// </summary>
    public class AdimistrativeZoneResearchModel : ResearchModel<AdministrativeZone>
    {
        /// <summary>
        /// <see cref="AdministrativeZone.Wording"/>
        /// </summary>
        public string Wording { get; set; }

        /// <summary>
        /// <see cref="ResearchModel{T}.Build"/>
        /// </summary>
        public override Expression<Func<AdministrativeZone, bool>> Build()
        {
            if (!string.IsNullOrEmpty(Wording))
                base.Add(city => city.Wording.ToUpper(CultureInfo.InvariantCulture).Contains(Wording.ToUpper(CultureInfo.InvariantCulture)));

            return this.CurrentExpressions;
        }
    }
}
