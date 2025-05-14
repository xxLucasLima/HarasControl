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
    public class HarasConfiguration : IEntityTypeConfiguration<Haras>
    {
        public void Configure(EntityTypeBuilder<Haras> builder)
        {
            builder.ToTable("Haras");
            builder.HasKey(h => h.Id);

            builder.Property(h => h.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(h => h.OwnerId)
                   .IsRequired();

            // Index on OwnerId for queries
            builder.HasIndex(h => h.OwnerId);
        }
    }
}
