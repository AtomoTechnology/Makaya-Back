using Customer.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers.Persistence.DataBase.Configuration
{
    public class CountryConfiguration
    {
        public CountryConfiguration(EntityTypeBuilder<Country> entitybuilder)
        {
            entitybuilder.HasKey(u => u.CountryId);
            entitybuilder.Property(u => u.CountryName).IsRequired().HasMaxLength(100);
        }
    }
}
