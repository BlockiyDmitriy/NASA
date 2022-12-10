using Fluxor;
using Nasa.Client.Services.DataServices.APODServices;
using Nasa.Client.Services.DataServices.AsteroidServices;
using Nasa.Client.Services.HttpServices.RestServices;
using Nasa.Client.Services.LoggerServices;
using Nasa.Client.Services.NavigationServices;
using Nasa.Client.StateManagement.APOD.Services;

namespace Nasa.Client.Services.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            //Fluxor and state management -------------------------------
            services.AddFluxor(options =>
            {
                options.ScanAssemblies(typeof(Program).Assembly).UseReduxDevTools();
            });
            services.AddScoped<IApodStateService, ApodStateService>();

            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<ILogService, LogService>();

            services.AddScoped<IRestApiService, RestApiService>();
            services.AddScoped<IGetApodDataService, GetApodDataService>();
            services.AddScoped<IAsteroidService, AsteroidService>();


            return services;
        }
    }
}
