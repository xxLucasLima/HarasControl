using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArasControl.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ArasControl.Infrastructure.Persistence.Configurations
{
    public class HarasOwnerConfiguration : IEntityTypeConfiguration<HarasOwner>
    {
        public void Configure(EntityTypeBuilder<HarasOwner> builder)
        {
            builder.ToTable("HarasOwners");
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(o => o.Email)
                   .IsRequired()
                   .HasMaxLength(200);
        }
    }
}
