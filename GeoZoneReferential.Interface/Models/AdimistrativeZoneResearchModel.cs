using GeoZoneReferential.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GeoZoneReferential.Interface.Models
{
    /// <summary>
    /// Design to describe parameter of research of an administrative zone
    /// </summary>
    public class AdimistrativeZoneResearchModel : ResearchModel<AdministrativeZone>
    {
        public string Wording { get; set; }

        public AdimistrativeZoneResearchModel() : base() { }

        public Expression<Func<AdministrativeZone, bool>> Build()
        {
            if (!string.IsNullOrEmpty(Wording))
                base.Add(city => city.Wording.ToUpper(CultureInfo.InvariantCulture).Contains(Wording.ToUpper(CultureInfo.InvariantCulture)));

            return this.CurrentExpressions;
        }
    }
}
