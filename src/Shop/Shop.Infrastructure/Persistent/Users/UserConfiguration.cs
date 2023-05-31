using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "user");
            builder.HasIndex(q => q.PhoneNumber).IsUnique();
            builder.HasIndex(q => q.Email).IsUnique();
            builder.HasIndex(q => q.NationalCode).IsUnique();
            builder.Property(q => q.FullName).IsRequired().HasMaxLength(50);
            builder.Property(q => q.PhoneNumber).IsRequired().HasMaxLength(11);
            builder.Property(q => q.Email).IsRequired().HasMaxLength(100);
            builder.Property(q => q.Password).IsRequired();
        }
    }
}
