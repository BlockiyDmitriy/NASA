using Fluxor;
using Nasa.Client.Models.Asteroids;

namespace Nasa.Client.StateManagement.Asteroid.UseCases
{
    [FeatureState]
    public class RecentAsteroidState
    {
        public IEnumerable<RecentAsteroidModel> RecentAsteroids { get; }

        public RecentAsteroidState() { }

        public RecentAsteroidState(IEnumerable<RecentAsteroidModel> recentAsteroids)
        {
            RecentAsteroids = recentAsteroids;
        }
    }
}
