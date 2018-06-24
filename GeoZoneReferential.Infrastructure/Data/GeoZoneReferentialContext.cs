using GeoZoneReferential.Domain.Entities;
using GeoZoneReferential.Domain.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GeoZoneReferential.Infrastructure.Data
{
    public class GeoZoneReferentialContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<AdministrativeLevelZone> AdministrativeLevelZones { get; set; }
        public DbSet<AdministrativeZone> AdministrativeZones { get; set; }

        public GeoZoneReferentialContext(DbContextOptions<GeoZoneReferentialContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// <see cref="DbContext.OnModelCreating(ModelBuilder)"/>
        /// </summary>
        /// <remarks>See 
        /// https://stackoverflow.com/questions/49326769/entity-framework-core-delete-cascade-and-required 
        /// https://stackoverflow.com/questions/18889218/unique-key-constraints-for-multiple-columns-in-entity-framework</remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>(entity => {
                entity.Property(country => country.Wording).IsRequired();
                entity.Property(country => country.ISO3166A2Code).IsRequired();
                entity.HasIndex(country => country.ISO3166A2Code).IsUnique();
                entity.HasIndex(country => country.Wording).IsUnique();
                entity.HasIndex(country => new { country.ISO3166A2Code, country.Wording }).IsUnique();
                entity.HasOne(country => country.CountryOwner).WithOne().OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<City>(entity => {
                entity.Property(city => city.Wording).IsRequired();
                entity.HasIndex(city => city.WordingS42Standard).IsUnique();
                entity.HasIndex(city => new { city.WordingS42Standard, city.PostalCode}).IsUnique();
                entity.HasOne(city => city.Country).WithOne().OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(city => city.AdministrativeZone).WithOne().OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AdministrativeZone>(entity =>
            {
                entity.Property(administrativeZones => administrativeZones.Wording).IsRequired();
                entity.Property(administrativeZones => administrativeZones.ISO3166A2Code).IsRequired();
                entity.HasOne(administrativeZones => administrativeZones.AdministrativeLevelZone).WithOne().OnDelete(DeleteBehavior.Restrict);
            });
        }

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