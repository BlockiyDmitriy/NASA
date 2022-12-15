using Nasa.Client.Models.Asteroids;

namespace Nasa.Client.StateManagement.Asteroid.Services
{
    public interface IAsteroidStateService
    {
        public Task SetRecentAsteroidData(RecentAsteroidModel recentAsteroidsData);
    }
}
