using Estudos.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Estudos.Data.Repositories;
using Estudos.Domain.Interfaces;
using Estudos.Application.Login;
using Estudos.Application.Services;
using Estudos.Domain.Validator;
using FluentValidation.AspNetCore;
using Estudos.Api.ViaCepService;
using Microsoft.Extensions.Configuration;
using Estudos.Application.Interfaces.ApiServices;
using Estudos.Api.ApiServices;

namespace Estudos.CrossCutting
{
    public static class BootStrap
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            AddApplicationSetup(services);
            AddDomainSetup(services);
            AddInfraSetup(services);
            AddAValidationSetup(services);
            AddAConfigHttpClient(services, configuration);

            return services;
        }

        private static void AddApplicationSetup(this IServiceCollection services)
        {
            services
                .AddScoped<IUsuarioService, UsuarioService>()
                .AddScoped<IClienteService, ClienteService>()
                .AddScoped<IAutenticacaoApiService, AutenticacaoApiService>();
    
                
        }

        private static void AddDomainSetup(this IServiceCollection services)
        {
            services
                .AddScoped<ICachingService, CachingService>()
                .AddScoped<IUsuarioRepository, UsuarioRepository>()
                .AddScoped<IClienteRepository, ClienteRepository>()
                .AddScoped<IViaCepService, ViaCepService>();
        }

        private static void AddAValidationSetup(this IServiceCollection services)
        {
            services
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ClienteValidator>());
        }

        private static void AddAConfigHttpClient(this IServiceCollection services,  IConfiguration configuration)
        {
            services.AddHttpClient<IViaCepService, ViaCepService>(client =>
            {
                client.BaseAddress = new Uri(configuration.GetSection("ViaCep:Url").Value);
            });

            //services.AddHttpClient<IAutenticacaoApiService, AutenticacaoApiService>(client => 
            //client)
        }

        private static void AddInfraSetup(IServiceCollection services)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        }
    }
}
