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
            IList<AdministrativeLevelZone> administrativeLevelZones = new List<AdministrativeLevelZone>
            {
                new AdministrativeLevelZone { Level = 1, Wording = "Région", CountryId = context.Countries.Single( c => c.ISO3166A2Code == "FR").Id },
                new AdministrativeLevelZone { Level = 2, Wording = "Département", CountryId = context.Countries.Single( c => c.ISO3166A2Code == "FR").Id },
                new AdministrativeLevelZone { Level = 1, Wording = "Etat", CountryId = context.Countries.Single( c => c.ISO3166A2Code == "US").Id }
            };
            context.AdministrativeLevelZones.AddRange(administrativeLevelZones);
            context.SaveChanges();

            IList<AdministrativeZone> administrativeZones = new List<AdministrativeZone>
            {
                new AdministrativeZone { AdministrativeLevelZoneId = administrativeLevelZones.Single(a => a.CountryId == context.Countries.Single( c => c.ISO3166A2Code == "FR").Id && a.Level == 1).Id, Wording = "Grand-Est", ISO3166A2Code = "FR-GES" },
                new AdministrativeZone { AdministrativeLevelZoneId = administrativeLevelZones.Single(a => a.CountryId == context.Countries.Single( c => c.ISO3166A2Code == "FR").Id && a.Level == 2).Id, Wording = "Bas-Rhin", ISO3166A2Code = "FR-67", ISO3166A2ParentCode = "FR-GES" },
                new AdministrativeZone { AdministrativeLevelZoneId = administrativeLevelZones.Single(a => a.CountryId == context.Countries.Single( c => c.ISO3166A2Code == "FR").Id && a.Level == 2).Id, Wording = "Haut-Rhin", ISO3166A2Code = "FR-68", ISO3166A2ParentCode = "FR-GES" }
            };
            context.AdministrativeZones.AddRange(administrativeZones);
            context.SaveChanges();

            IList<City> cities = new List<City>
            {
                new City { Wording = "Strasbourg", WordingS42Standard = "STRASBOURG", PostalCode = "67000", AdministrativeZoneId = administrativeZones.Single(a => a.ISO3166A2Code == "FR-67").Id },
                new City { Wording = "Colmar", WordingS42Standard = "COLMAR", PostalCode = "68000", AdministrativeZoneId = administrativeZones.Single(a => a.ISO3166A2Code == "FR-68").Id }
            };

            context.Cities.AddRange(cities);
            context.SaveChanges();
        }
    }
}
