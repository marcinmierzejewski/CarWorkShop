using CarWorkShop.Application.CarWorkShop.Commands.CreateCarWorkShop;
using CarWorkShop.Application.Mappings;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
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
            services.AddMediatR(typeof(CreateCarWorkShopCommand));

            services.AddAutoMapper(typeof(CarWorkShopMappingProfile));

            services.AddValidatorsFromAssemblyContaining<CreateCarWorkShopCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }

    }
}
