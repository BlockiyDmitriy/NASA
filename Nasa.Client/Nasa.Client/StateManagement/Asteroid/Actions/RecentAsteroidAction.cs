using Nasa.Client.Models.Asteroids;

namespace Nasa.Client.StateManagement.Asteroid.Actions
{
    public class RecentAsteroidAction
    {
        public IEnumerable<RecentAsteroidModel> RecentAsteroids { get; }

        public RecentAsteroidAction(IEnumerable<RecentAsteroidModel> recentAsteroids)
        {
            RecentAsteroids = recentAsteroids;
        }
    }
}
