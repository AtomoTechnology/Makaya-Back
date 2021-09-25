using Customer.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers.Persistence.DataBase.Configuration
{
    public class UserConfiguration
    {
        public UserConfiguration(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasIndex( u => u.UserId);
            entityBuilder.Property(u => u.AccountId).IsRequired();
            entityBuilder.Property(u => u.Firstname).HasMaxLength(100);
            entityBuilder.Property(u => u.Lastname).HasMaxLength(100);
            entityBuilder.Property(u => u.EmailAddress).HasMaxLength(150);
            entityBuilder.Property(u => u.Address).HasMaxLength(250);
            entityBuilder.Property(u => u.NumberAddress).HasMaxLength(50);
        }
    }
}
