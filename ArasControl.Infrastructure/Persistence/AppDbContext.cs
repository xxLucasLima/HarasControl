using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArasControl.Domain.Entities;
using ArasControl.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ArasControl.Infrastructure.Persistence
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Haras> Haras { get; set; }
        public DbSet<HarasOwner> HarasOwners { get; set; }
        public DbSet<AnimalOwner> AnimalOwners { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<FeedInventory> FeedInventories { get; set; }
        public DbSet<FeedRecord> FeedRecords { get; set; }
        public DbSet<VaccineRecord> VaccineRecords { get; set; }
        public DbSet<VitaminDose> VitaminDoses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.OwnsOne(a => a.Dimensions);
            });
        }
    }
}
