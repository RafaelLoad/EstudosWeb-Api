using Estudos.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Estudos.Data.Context;
using Estudos.Data.Repositories;
using Estudos.Domain.Interfaces;
using Estudos.Application.Produto;
using Estudos.Application.Login;

namespace Estudos.CrossCutting
{
    public static class BootStrap
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            AddApplicationSetup(services);
            AddDomainSetup(services);
            AddInfraSetup(services);

            return services;
        }

        private static void AddApplicationSetup(this IServiceCollection services)
        {
            services
                .AddScoped<ILibraryService, LibraryService>()
                .AddScoped<ILoginService, LoginService>();
        }

        private static void AddDomainSetup(this IServiceCollection services)
        {
            services.AddScoped<ILibraryRepository, LibraryRepository>();
        }

        private static void AddInfraSetup(IServiceCollection services)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        }
    }
}