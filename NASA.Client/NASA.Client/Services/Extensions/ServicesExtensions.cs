using Microsoft.Extensions.DependencyInjection;
using NASA.Client.Services.DataServices.APODServices;
using NASA.Client.Services.HttpServices.RestServices;
using NASA.Client.Services.LoggerServices;
using NASA.Client.Services.NavigationServices;

namespace NASA.Client.Services.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<ILogService, LogService>();

            services.AddScoped<IRestApiService, RestApiService>();
            services.AddScoped<IGetApodData, GetApodData>();

            return services;
        }
    }
}
