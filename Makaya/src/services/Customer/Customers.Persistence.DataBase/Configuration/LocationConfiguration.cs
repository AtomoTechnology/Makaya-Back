using Customer.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers.Persistence.DataBase.Configuration
{
    public class LocationConfiguration
    {
        public LocationConfiguration(EntityTypeBuilder<Location> entityBuilder)
        {
            entityBuilder.HasKey(u => u.LocationId);
            entityBuilder.Property(u => u.CityId).IsRequired();
            entityBuilder.Property(u => u.CountryId).IsRequired();
            entityBuilder.Property(u => u.ProvinceId).IsRequired();
        }
    }
}
