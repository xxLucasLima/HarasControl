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
    public class VaccineRecordConfiguration : IEntityTypeConfiguration<VaccineRecord>
    {
        public void Configure(EntityTypeBuilder<VaccineRecord> builder)
        {
            builder.ToTable("VaccineRecords");
            builder.HasKey(vr => vr.Id);

            builder.Property(vr => vr.VaccineName)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(vr => vr.AdministeredAt).IsRequired();
            builder.Property(vr => vr.NextDue);
            builder.Property(vr => vr.FrequencyDays);
            builder.Property(vr => vr.ReminderDaysBefore).IsRequired();
            builder.Property(vr => vr.ReminderEnabled).IsRequired();
            builder.Property(vr => vr.Notes).HasMaxLength(500);

            builder.HasOne<Animal>()
                   .WithMany(a => a.VaccineRecords)
                   .HasForeignKey(vr => vr.AnimalId);
        }
    }
}
