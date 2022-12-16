using Nasa.Client.MapperServices;
using Nasa.Client.Models.Asteroids;
using Nasa.Client.Services.HttpServices.RestServices;
using Nasa.Client.Services.LoggerServices;
using Nasa.Client.StateManagement.Asteroid.Services;

namespace Nasa.Client.Services.DataServices.AsteroidServices
{
    public class AsteroidService : IAsteroidService
    {
        private readonly IRestApiService _restApiService;
        private readonly ILogService _logService;
        private readonly IAsteroidStateService _asteroidStateService;

        public AsteroidService(IRestApiService restApiService, ILogService logService, IAsteroidStateService asteroidStateService)
        {
            _restApiService = restApiService;
            _logService = logService;
            _asteroidStateService = asteroidStateService;
        }

        public async Task<IEnumerable<RecentAsteroidModel>> GetRecentAsteroids()
        {
            try
            {
                await _logService.LogAsync(nameof(GetRecentAsteroids));

                var recentAsteroidsDto = await _restApiService.GetRecentAsteroids(DateTimeOffset.UtcNow.Date, DateTimeOffset.UtcNow.Date);

                var recentAsteroidsData = Mapper.GetAsteroidDtoToRecentAsteroidModel(new Data.Models.AsteroidDTOs.NearObjectDTO());

                await _asteroidStateService.SetRecentAsteroidData(recentAsteroidsData);

                return new List<RecentAsteroidModel>();
            }
            catch (Exception e)
            {
                await _logService.TrackExceptionAsync(e, nameof(RecentAsteroidModel), nameof(GetRecentAsteroids));

                return new List<RecentAsteroidModel>();
            }
        }
    }
}
