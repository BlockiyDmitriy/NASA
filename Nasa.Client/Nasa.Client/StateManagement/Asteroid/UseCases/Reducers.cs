using Fluxor;
using Nasa.Client.StateManagement.Asteroid.Actions;

namespace Nasa.Client.StateManagement.Asteroid.UseCases
{
    public static class Reducers
    {
        [ReducerMethod]
        public static RecentAsteroidState ReduceRecentAsteroid(RecentAsteroidState state, RecentAsteroidAction action) =>
            new();
    }
}
