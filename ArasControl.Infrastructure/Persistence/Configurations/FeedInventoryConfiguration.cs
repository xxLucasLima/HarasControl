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
    public class FeedInventoryConfiguration : IEntityTypeConfiguration<FeedInventory>
    {
        public void Configure(EntityTypeBuilder<FeedInventory> builder)
        {
            builder.ToTable("FeedInventories");
            builder.HasKey(fi => fi.Id);

            builder.Property(fi => fi.CurrentQuantity).IsRequired();
            builder.Property(fi => fi.Unit)
                   .IsRequired()
                   .HasMaxLength(20);
            builder.Property(fi => fi.ThresholdQuantity).IsRequired();
            builder.Property(fi => fi.AlertEnabled).IsRequired();

            builder.HasOne<Animal>()
                   .WithOne()
                   .HasForeignKey<FeedInventory>(fi => fi.AnimalId);
        }
    }
}
