using GeoZoneReferential.Domain.Entities;
using GeoZoneReferential.Domain.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GeoZoneReferential.Infrastructure.Data
{
    public class GeoZoneReferentialContext : DbContext
    {
        public GeoZoneReferentialContext(DbContextOptions<GeoZoneReferentialContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

        public override int SaveChanges()
        {
            var lTimestampableEntities = ChangeTracker.Entries<ITimestampable>()
                .Select(e => e.Entity)
                .ToArray();

            foreach (var lEntity in lTimestampableEntities)
            {
                lEntity.OperationDate = DateTime.UtcNow;
            }

            int result = base.SaveChanges();

            return result;
        }
    }
}