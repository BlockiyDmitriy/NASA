using Nasa.Client.MapperServices;
using Nasa.Client.Models.Asteroids;
using Nasa.Client.Services.HttpServices.RestServices;
using Nasa.Client.Services.LoggerServices;

namespace Nasa.Client.Services.DataServices.AsteroidServices
{
    public class AsteroidService : IAsteroidService
    {
        private readonly IRestApiService _restApiService;
        private readonly ILogService _logService;

        public AsteroidService(IRestApiService restApiService, ILogService logService)
        {
            _restApiService = restApiService;
            _logService = logService;
        }

        public async Task<RecentAsteroidModel> GetRecentAsteroids()
        {
            try
            {
                await _logService.LogAsync(nameof(GetRecentAsteroids));

                var recentAsteroidsDto = await _restApiService.GetRecentAsteroids(DateTimeOffset.UtcNow.Date, DateTimeOffset.UtcNow.Date);

                var recentAsteroidsData = Mapper.GetAsteroidDtoToRecentAsteroidModel(recentAsteroidsDto);

                return recentAsteroidsData;
            }
            catch (Exception e)
            {
                await _logService.TrackExceptionAsync(e, nameof(RecentAsteroidModel), nameof(GetRecentAsteroids));

                return new RecentAsteroidModel();
            }
        }
    }
}
