using ArasControl.Domain.Entities;
using ArasControl.Domain.Entities.Enum;
using ArasControl.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ArasControl.Infrastructure.Persistence
{
    public static class DbInitializer
    {
        /// <summary>
        /// Aplica migrações, garante as roles e popula o banco com dados de teste se estiver vazio.
        /// </summary>
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            // Resolve o contexto e o RoleManager
            var context = serviceProvider.GetRequiredService<AppDbContext>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Aplica migrations pendentes
            context.Database.Migrate();

            // Cria roles se não existirem
            string[] roles = new[] { "HarasOwner", "AnimalOwner" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // Se já existe ao menos um Haras, presume que já foi seedado
            if (context.Haras.Any())
                return;

            // Cria HarasOwner
            var harasOwner = new HarasOwner(
                Guid.NewGuid(),
                "Sample Haras Owner",
                "owner@sampleharas.com"
            );
            context.HarasOwners.Add(harasOwner);

            // Cria Haras
            var haras = new Haras(
                Guid.NewGuid(),
                "Sample Haras",
                harasOwner.Id
            );
            context.Haras.Add(haras);

            // Cria AnimalOwner
            var animalOwner = new AnimalOwner(
                Guid.NewGuid(),
                "Sample Animal Owner",
                "animalowner@sampleharas.com",
                haras.Id
            );
            context.AnimalOwners.Add(animalOwner);

            // Cria 4 animais com dados relacionados
            for (int i = 1; i <= 4; i++)
            {
                var animal = new Animal(
                    Guid.NewGuid(),
                    $"Horse #{i}",
                    "Thoroughbred",
                    "Chestnut",
                    new AnimalDimensions(500 + i * 10, 160 + i),
                    haras.Id,
                    animalOwner.Id,
                    DateTime.UtcNow.AddYears(-3).AddMonths(i),
                    Gender.Stallion,
                    $"MC{i:00000}",
                    $"REG{i:00000}",
                    "Calm",
                    "No significant medical history"
                );
                context.Animals.Add(animal);

                // Estoque de ração
                var inventory = new FeedInventory(
                    Guid.NewGuid(),
                    animal.Id,
                    100m,
                    "kg",
                    20m
                );
                context.FeedInventories.Add(inventory);

                // FeedRecord de exemplo
                var feedRecord = new FeedRecord(
                    Guid.NewGuid(),
                    animal.Id,
                    5m,
                    "kg",
                    DateTime.UtcNow.AddDays(-1)
                );
                context.FeedRecords.Add(feedRecord);

                // VaccineRecord de exemplo
                var vaccineRecord = new VaccineRecord(
                    Guid.NewGuid(),
                    animal.Id,
                    "Rabies",
                    DateTime.UtcNow.AddMonths(-6),
                    DateTime.UtcNow.AddMonths(6),
                    frequencyDays: 365,
                    reminderDaysBefore: 30
                );
                context.VaccineRecords.Add(vaccineRecord);

                // VitaminDose de exemplo
                var vitaminDose = new VitaminDose(
                    Guid.NewGuid(),
                    animal.Id,
                    "Vitamin B",
                    5m,
                    "mg",
                    DateTime.UtcNow.AddDays(-2)
                );
                context.VitaminDoses.Add(vitaminDose);
            }

            context.SaveChanges();
        }
    }
}
