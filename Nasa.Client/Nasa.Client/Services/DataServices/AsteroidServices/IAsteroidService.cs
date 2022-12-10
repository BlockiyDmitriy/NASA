using Nasa.Client.Models.Asteroids;

namespace Nasa.Client.Services.DataServices.AsteroidServices
{
    public interface IAsteroidService
    {
        public Task<IEnumerable<RecentAsteroidModel>> GetRecentAsteroids();
    }
}
