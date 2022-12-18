using Nasa.Client.Models.Asteroids;

namespace Nasa.Client.StateManagement.Asteroid.Services
{
    public interface IAsteroidStateService
    {
        public Task SetRecentAsteroidsData(IEnumerable<RecentAsteroidModel> recentAsteroidsData);
    }
}
