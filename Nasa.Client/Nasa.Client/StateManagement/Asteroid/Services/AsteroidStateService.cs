using Fluxor;
using Nasa.Client.Models.Asteroids;
using Nasa.Client.Services.LoggerServices;
using Nasa.Client.StateManagement.Asteroid.Actions;

namespace Nasa.Client.StateManagement.Asteroid.Services
{
    public class AsteroidStateService : IAsteroidStateService
    {
        private readonly ILogService _logService;
        private readonly IDispatcher _dispatcher;

        public AsteroidStateService(ILogService logService, IDispatcher dispatcher)
        {
            _logService = logService;
            _dispatcher = dispatcher;
        }

        public async Task SetRecentAsteroidData(RecentAsteroidModel recentAsteroidsData)
        {
            try
            {
                await _logService.LogAsync(nameof(SetRecentAsteroidData));

                var action = new RecentAsteroidAction(new List<RecentAsteroidModel>());

                _dispatcher.Dispatch(action);
            }
            catch (Exception e)
            {
                await _logService.TrackExceptionAsync(e, this.GetType().FullName, nameof(SetRecentAsteroidData));
            }
        }
    }
}
