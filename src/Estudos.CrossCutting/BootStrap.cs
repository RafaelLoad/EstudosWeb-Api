using Estudos.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Estudos.Data.Context;
using Estudos.Data.Repositories;
using Estudos.Domain.Interfaces;
using Estudos.Application.Login;
using Estudos.Application.Services;
using Estudos.Domain.Validator;
using FluentValidation.AspNetCore;

namespace Estudos.CrossCutting
{
    public static class BootStrap
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            AddApplicationSetup(services);
            AddDomainSetup(services);
            AddInfraSetup(services);
            AddAValidationSetup(services);

            return services;
        }

        private static void AddApplicationSetup(this IServiceCollection services)
        {
            services
                .AddScoped<ILoginService, LoginService>()
                .AddScoped<IClienteService, ClienteService>();
        }

        private static void AddDomainSetup(this IServiceCollection services)
        {
            services
                .AddScoped<ILoginService, LoginService>()
                .AddScoped<IClienteRepository, ClienteRepository>();
        }

        private static void AddAValidationSetup(this IServiceCollection services)
        {
            services
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ClienteValidator>());
        } 

        private static void AddInfraSetup(IServiceCollection services)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        }
    }
}