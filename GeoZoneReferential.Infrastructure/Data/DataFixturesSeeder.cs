using GeoZoneReferential.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoZoneReferential.Infrastructure.Data
{
    public class DataFixturesSeeder
    {
        public static void Initialize(GeoZoneReferentialContext context)
        {
            Country country = new Country { ISO3166A2Code = "FR", Wording = "France" };
            context.Countries.Add(country);
            context.SaveChanges();

            AdministrativeLevelZone administrativeLevelZone = new AdministrativeLevelZone { Level = 1, Wording = "Région", CountryId = country.Id };
            context.AdministrativeLevelZones.Add(administrativeLevelZone);
            context.SaveChanges();

            IList<AdministrativeZone> administrativeZones = new List<AdministrativeZone>
            {
                new AdministrativeZone { AdministrativeLevelZoneId = administrativeLevelZone.Id, Wording = "Grand-Est", ISO3166A2Code = "FR-GES" },
                new AdministrativeZone { AdministrativeLevelZoneId = administrativeLevelZone.Id, Wording = "Bas-Rhin", ISO3166A2Code = "FR-67" }
            };
            context.AdministrativeZones.AddRange(administrativeZones);
            context.SaveChanges();

            City city = new City { CountryId = country.Id, Wording = "Strasbourg", PostalCode = "67000", AdministrativeZoneId = administrativeZones.Last().Id };
            context.Cities.Add(city);
            context.SaveChanges();
        }
    }
}
