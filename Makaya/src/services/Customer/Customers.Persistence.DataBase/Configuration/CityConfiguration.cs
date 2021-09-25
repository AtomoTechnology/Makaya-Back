using Customer.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers.Persistence.DataBase.Configuration
{
    public class CityConfiguration
    {
        public CityConfiguration(EntityTypeBuilder<City> entitybuilder)
        {
            entitybuilder.HasKey( u => u.CityId);
            entitybuilder.Property(u => u.ProvinceId).IsRequired();
            entitybuilder.Property(u => u.CityName).IsRequired().HasMaxLength(100);
        }
    }
}
