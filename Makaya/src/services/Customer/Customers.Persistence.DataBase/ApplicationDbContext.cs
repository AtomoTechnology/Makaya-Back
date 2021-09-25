using Customer.Domain;
using Customers.Persistence.DataBase.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Customers.Persistence.DataBase
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }

        #region Dbset
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Province> Provinces { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.HasDefaultSchema("Makaya");
            ModelConfig(modelBuilder);
        }


        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new UserConfiguration(modelBuilder.Entity<User>());
            new CityConfiguration(modelBuilder.Entity<City>());
            new CountryConfiguration(modelBuilder.Entity<Country>());
            new ProvinceConfiguration(modelBuilder.Entity<Province>());
            new LocationConfiguration(modelBuilder.Entity<Location>());
        }
    }
}
