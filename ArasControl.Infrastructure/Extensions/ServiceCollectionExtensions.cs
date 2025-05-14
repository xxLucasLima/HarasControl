using ArasControl.Domain.Interfaces;
using ArasControl.Infrastructure.Persistence;
using ArasControl.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArasControl.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default"))
            );

            // Repositórios 
            services.AddScoped<IHarasRepository, HarasRepository>();
            services.AddScoped<IHarasOwnerRepository, HarasOwnerRepository>();
            services.AddScoped<IAnimalOwnerRepository, AnimalOwnerRepository>();
            services.AddScoped<IAnimalRepository, AnimalRepository>();
            services.AddScoped<IFeedInventoryRepository, FeedInventoryRepository>();

            return services;
        }
    }
}