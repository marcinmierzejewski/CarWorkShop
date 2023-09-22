using CarWorkShop.Domain.Interfaces;
using CarWorkShop.Infrastructure.Persistence;
using CarWorkShop.Infrastructure.Seeders;
using CarWorkShop.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

namespace CarWorkShop.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration )
        {
            services.AddDbContext<CarWorkShopDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("CarWorkShop")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<CarWorkShopDbContext>();

            services.AddScoped<CarWorkShopSeeder>();

            services.AddScoped<ICarWorkShopRepository, CarWorkShopRepository>();
        }
    }
}
