using Estudos.Api.ApiServices;
using Estudos.Application.Interfaces.ApiServices;

namespace Estudos.Web.Middleware
{
    public static class HttpDependenciesMiddleware
    {
        public static void RegisterHttpServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IAutenticacaoApiService, AutenticacaoApiService>(client =>
            {
                client.BaseAddress = new Uri(configuration.GetSection("ApiSettings:UrlAutenticacao").Value);
            });
        }
    }
}