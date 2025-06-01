using ArasControl.Domain.Entities;
using ArasControl.Domain.Entities.Enum;
using ArasControl.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using ArasControl.Domain.Entities.Auth;

namespace ArasControl.Infrastructure.Persistence
{
    public static class DbInitializer
    {
        /// <summary>
        /// Aplica migrações, garante as roles e popula o banco com dados de teste se estiver vazio.
        /// </summary>
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Aplica migrations pendentes
            context.Database.Migrate();

            // CRIANDO ROLES
            string[] roles = new[] { "HarasOwner", "AnimalOwner" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // CRIANDO USUÁRIOS PADRÃO

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

            // Cria AnimalOwner para o HarasOwner, garantindo integridade das FKs!
            var harasOwnerAsAnimalOwner = new AnimalOwner(
                harasOwner.Id,
                harasOwner.Name,
                harasOwner.Email,
                haras.Id
            );
            context.AnimalOwners.Add(harasOwnerAsAnimalOwner);

            context.SaveChanges(); // <-- Salva entidades principais antes dos filhos!
            // Usuário HarasOwner
            var harasOwnerEmail = "harasowner@sample.com";
            if (await userManager.FindByEmailAsync(harasOwnerEmail) == null)
            {
                var user = new ApplicationUser
                {
                    UserName = harasOwnerEmail,
                    Email = harasOwnerEmail,
                    EmailConfirmed = true,
                    RoleType = "HarasOwner",
                    HarasId = haras.Id,

                };
                await userManager.CreateAsync(user, "SenhaForte123!");
                await userManager.AddToRoleAsync(user, "HarasOwner");
            }

            // Usuário AnimalOwner
            var animalOwnerEmail = "animalowner@sample.com";
            if (await userManager.FindByEmailAsync(animalOwnerEmail) == null)
            {
                var user = new ApplicationUser
                {
                    UserName = animalOwnerEmail,
                    Email = animalOwnerEmail,
                    EmailConfirmed = true,
                    RoleType = "AnimalOwner",
                    HarasId = haras.Id,
                };
                await userManager.CreateAsync(user, "SenhaForte123!");
                await userManager.AddToRoleAsync(user, "AnimalOwner");
            }

            // Dados dos 4 cavalos do animalOwner
            string[] animalOwnerNames = { "Horse #1", "Horse #2", "Horse #3", "Horse #4" };
            string[] animalOwnerBreeds = { "Thoroughbred", "Arabian", "Quarter Horse", "Criollo" };
            string[] animalOwnerColors = { "Chestnut", "Gray", "Bay", "Roan" };
            Gender[] animalOwnerGenders = { Gender.Stallion, Gender.Mare, Gender.Gelding, Gender.Mare };
            double[] animalOwnerWeights = { 510, 520, 530, 540 };
            double[] animalOwnerHeights = { 161, 162, 163, 164 };
            string[] animalOwnerMicrochips = { "MC00001", "MC00002", "MC00003", "MC00004" };
            string[] animalOwnerRegs = { "REG00001", "REG00002", "REG00003", "REG00004" };
            string[] animalOwnerTemperaments = { "Calm", "Energetic", "Docile", "Nervous" };
            string[] animalOwnerMedical = {
                "No significant medical history",
                "Mild colic episode 2022",
                "Vaccinated regularly",
                "Recovered from hoof injury"
            };

            for (int i = 0; i < 4; i++)
            {
                var animal = new Animal(
                    Guid.NewGuid(),
                    animalOwnerNames[i],
                    animalOwnerBreeds[i],
                    animalOwnerColors[i],
                    new AnimalDimensions(animalOwnerWeights[i], animalOwnerHeights[i]),
                    haras.Id,
                    animalOwner.Id,
                    DateTime.UtcNow.AddYears(-3).AddMonths(i + 1),
                    animalOwnerGenders[i],
                    animalOwnerMicrochips[i],
                    animalOwnerRegs[i],
                    animalOwnerTemperaments[i],
                    animalOwnerMedical[i]
                );
                context.Animals.Add(animal);

                context.FeedInventories.Add(new FeedInventory(
                    Guid.NewGuid(),
                    animal.Id,
                    100m + i * 5,
                    "kg",
                    20m + i
                ));

                context.FeedRecords.Add(new FeedRecord(
                    Guid.NewGuid(),
                    animal.Id,
                    5m + i,
                    "kg",
                    DateTime.UtcNow.AddDays(-1 - i),
                    notes: ""
                ));

                context.VaccineRecords.Add(new VaccineRecord(
                    Guid.NewGuid(),
                    animal.Id,
                    "Rabies",
                    DateTime.UtcNow.AddMonths(-6),
                    DateTime.UtcNow.AddMonths(6),
                    frequencyDays: 365,
                    reminderDaysBefore: 30,
                    reminderEnabled: true,
                    notes: ""
                ));

                context.VitaminDoses.Add(new VitaminDose(
                    Guid.NewGuid(),
                    animal.Id,
                    "Vitamin B",
                    5m + i,
                    "mg",
                    DateTime.UtcNow.AddDays(-2 - i),
                    notes: ""
                ));
            }

            // Dados dos 4 cavalos do harasOwner
            string[] harasOwnerNames = { "Thunderbolt", "Golden Mane", "Night Shadow", "White Lightning" };
            string[] harasOwnerBreeds = { "Quarter Horse", "Arabian", "Appaloosa", "Mustang" };
            string[] harasOwnerColors = { "Bay", "Palomino", "Black", "Gray" };
            Gender[] harasOwnerGenders = { Gender.Mare, Gender.Stallion, Gender.Gelding, Gender.Mare };
            double[] harasOwnerWeights = { 492, 500, 515, 528 };
            double[] harasOwnerHeights = { 160, 162, 164, 166 };
            string[] harasOwnerMicrochips = { "MCX0001", "MCX0002", "MCX0003", "MCX0004" };
            string[] harasOwnerRegs = { "REGX0001", "REGX0002", "REGX0003", "REGX0004" };
            string[] harasOwnerTemperaments = { "Energetic", "Calm", "Skittish", "Docile" };
            string[] harasOwnerMedical = {
                "Had mild colic episode 2023",
                "No significant medical history",
                "Minor hoof injury 2022",
                "Vaccinated regularly"
            };

            for (int i = 0; i < 4; i++)
            {
                var animal = new Animal(
                    Guid.NewGuid(),
                    harasOwnerNames[i],
                    harasOwnerBreeds[i],
                    harasOwnerColors[i],
                    new AnimalDimensions(harasOwnerWeights[i], harasOwnerHeights[i]),
                    haras.Id,
                    harasOwner.Id,
                    DateTime.UtcNow.AddYears(-4).AddMonths(i + 1),
                    harasOwnerGenders[i],
                    harasOwnerMicrochips[i],
                    harasOwnerRegs[i],
                    harasOwnerTemperaments[i],
                    harasOwnerMedical[i]
                );
                context.Animals.Add(animal);

                context.FeedInventories.Add(new FeedInventory(
                    Guid.NewGuid(),
                    animal.Id,
                    115m + i * 5,
                    "kg",
                    20m + i
                ));

                context.FeedRecords.Add(new FeedRecord(
                    Guid.NewGuid(),
                    animal.Id,
                    7m + i,
                    "kg",
                    DateTime.UtcNow.AddDays(-1 - i),
                    notes: $"Ate {7 + i}kg of oats"
                ));

                context.VaccineRecords.Add(new VaccineRecord(
                    Guid.NewGuid(),
                    animal.Id,
                    i % 2 == 0 ? "Rabies" : "Influenza",
                    DateTime.UtcNow.AddMonths(-3 - i),
                    DateTime.UtcNow.AddMonths(3 + i),
                    frequencyDays: 180 + i * 30,
                    reminderDaysBefore: 20 + i * 5,
                    reminderEnabled: true,
                    notes: $"Vacina aplicada em {DateTime.UtcNow.AddMonths(-3 - i):yyyy-MM-dd}"
                ));

                context.VitaminDoses.Add(new VitaminDose(
                    Guid.NewGuid(),
                    animal.Id,
                    i % 2 == 0 ? "Vitamin E" : "Vitamin D",
                    9m + i,
                    "mg",
                    DateTime.UtcNow.AddDays(-3 - i),
                    notes: $"Dose extra aplicada em {DateTime.UtcNow.AddDays(-3 - i):yyyy-MM-dd}"
                ));
            }

            context.SaveChanges();
        }
    }
}
