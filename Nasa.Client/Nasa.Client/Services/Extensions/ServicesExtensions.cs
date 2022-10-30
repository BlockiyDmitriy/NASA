using Nasa.Client.Services.DataServices.APODServices;
using Nasa.Client.Services.HttpServices.RestServices;
using Nasa.Client.Services.LoggerServices;
using Nasa.Client.Services.NavigationServices;

namespace Nasa.Client.Services.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<ILogService, LogService>();

            services.AddScoped<IRestApiService, RestApiService>();
            services.AddScoped<IGetApodDataService, GetApodDataService>();

            return services;
        }
    }
}
