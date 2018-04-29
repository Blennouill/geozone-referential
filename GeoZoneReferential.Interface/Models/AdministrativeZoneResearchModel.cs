using GeoZoneReferential.Domain.Entities;
using System;
using System.Globalization;
using System.Linq.Expressions;

namespace GeoZoneReferential.Interface.Models
{
    /// <summary>
    /// Design to describe parameter of research of an administrative zone.
    /// </summary>
    public class AdministrativeZoneResearchModel : ResearchModel<AdministrativeZone>
    {
        /// <summary>
        /// <see cref="AdministrativeZone.Wording"/>
        /// </summary>
        public string Wording { get; set; }

        /// <summary>
        /// <see cref="AdministrativeZone.AdministrativeLevelZoneId"/>
        /// </summary>
        public int? AdministrativeLevelZoneId { get; set; }

        /// <summary>
        /// <see cref="ResearchModel{T}.Build"/>
        /// </summary>
        public override Expression<Func<AdministrativeZone, bool>> Build()
        {
            if (!string.IsNullOrEmpty(Wording))
                base.Add(administrativeZone => administrativeZone.Wording.ToUpper(CultureInfo.InvariantCulture).Contains(Wording.ToUpper(CultureInfo.InvariantCulture)));

            if (AdministrativeLevelZoneId.HasValue)
                base.Add(administrativeZone => administrativeZone.AdministrativeLevelZoneId == AdministrativeLevelZoneId);

            return this.CurrentExpressions;
        }
    }
}
