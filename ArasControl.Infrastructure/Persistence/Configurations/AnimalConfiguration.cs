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
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.ToTable("Animals");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.Breed)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.Color)
                   .IsRequired()
                   .HasMaxLength(50);

            // Owned type for dimensions
            builder.OwnsOne(a => a.Dimensions, d =>
            {
                d.Property(x => x.WeightKg).IsRequired();
                d.Property(x => x.HeightCm).IsRequired();
            });

            builder.Property(a => a.OwnerId)
                   .IsRequired();

            builder.Property(a => a.HarasId)
                   .IsRequired();

            builder.Property(a => a.DateOfBirth)
                   .IsRequired();

            builder.Property(a => a.Sex)
                   .IsRequired();

            builder.Property(a => a.MicrochipId)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(a => a.RegistrationNumber)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(a => a.Temperament)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.MedicalHistory)
                   .HasMaxLength(1000);

            // Relationships
            builder.HasOne<AnimalOwner>()
                   .WithMany(o => o.Animals)
                   .HasForeignKey(a => a.OwnerId);

            builder.HasOne<Haras>()
                   .WithMany()
                   .HasForeignKey(a => a.HarasId);
        }
    }
}
