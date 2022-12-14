using Nasa.Client.Models.Asteroids;
using Nasa.Client.Services.LoggerServices;

namespace Nasa.Client.StateManagement.Asteroid.Services
{
    public class AsteroidStateService : IAsteroidStateService
    {
        private readonly ILogService _logService;

        public AsteroidStateService(ILogService logService)
        {
            _logService = logService;
        }

        public async Task SetAsteroidsData(RecentAsteroidModel recentAsteroidsData)
        {
            try
            {

            }
            catch (Exception e)
            {
                await _logService.TrackExceptionAsync(e, this.GetType().FullName, nameof(SetAsteroidsData));
            }
        }
    }
}
