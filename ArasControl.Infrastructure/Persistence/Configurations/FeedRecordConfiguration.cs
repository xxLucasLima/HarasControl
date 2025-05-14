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
    public class FeedRecordConfiguration : IEntityTypeConfiguration<FeedRecord>
    {
        public void Configure(EntityTypeBuilder<FeedRecord> builder)
        {
            builder.ToTable("FeedRecords");
            builder.HasKey(fr => fr.Id);

            builder.Property(fr => fr.Amount).IsRequired();
            builder.Property(fr => fr.Unit)
                   .IsRequired()
                   .HasMaxLength(20);
            builder.Property(fr => fr.FedAt).IsRequired();
            builder.Property(fr => fr.Notes).HasMaxLength(500);

            builder.HasOne<Animal>()
                   .WithMany(a => a.FeedRecords)
                   .HasForeignKey(fr => fr.AnimalId);
        }
    }
}
