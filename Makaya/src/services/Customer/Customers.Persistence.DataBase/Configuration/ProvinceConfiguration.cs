using Customer.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers.Persistence.DataBase.Configuration
{
    public class ProvinceConfiguration
    {
        public ProvinceConfiguration(EntityTypeBuilder<Province> entitybuilder)
        {
            entitybuilder.HasKey(u => u.ProvinceId);
            entitybuilder.Property(u => u.CountryId).IsRequired();
            entitybuilder.Property(u => u.ProvinceName).IsRequired().HasMaxLength(100);
        }
    }
}
