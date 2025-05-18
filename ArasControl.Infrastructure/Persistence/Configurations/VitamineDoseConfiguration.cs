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
    public class VitaminDoseConfiguration : IEntityTypeConfiguration<VitaminDose>
    {
        public void Configure(EntityTypeBuilder<VitaminDose> builder)
        {
            builder.ToTable("VitaminDoses");
            builder.HasKey(vd => vd.Id);

            builder.Property(vd => vd.VitaminName)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(vd => vd.Amount).IsRequired().HasColumnType("decimal(10,2)");
            builder.Property(vd => vd.Unit)
                   .IsRequired()
                   .HasMaxLength(20);
            builder.Property(vd => vd.AdministeredAt).IsRequired();
            builder.Property(vd => vd.Notes).HasMaxLength(500);

            builder.HasOne<Animal>()
                   .WithMany(a => a.VitaminDoses)
                   .HasForeignKey(vd => vd.AnimalId);
        }
    }
}
