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
    public class AnimalOwnerConfiguration : IEntityTypeConfiguration<AnimalOwner>
    {
        public void Configure(EntityTypeBuilder<AnimalOwner> builder)
        {
            builder.ToTable("AnimalOwners");
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(o => o.Email)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(o => o.HarasId)
                   .IsRequired();

            builder.HasIndex(o => o.HarasId);
        }
    }
}
