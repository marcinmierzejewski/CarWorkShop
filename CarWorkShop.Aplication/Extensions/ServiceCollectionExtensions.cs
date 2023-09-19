using CarWorkShop.Application.CarWorkShop;
using CarWorkShop.Application.Mappings;
using CarWorkShop.Application.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICarWorkShopService, CarWorkShopService>();

            services.AddAutoMapper(typeof(CarWorkShopMappingProfile));

            services.AddValidatorsFromAssemblyContaining<CarWorkShopDtoValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }

    }
}
