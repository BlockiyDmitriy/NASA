namespace Nasa.Client.Models.Asteroids
{
    public class RecentAsteroidModel
    {
        public string Name { get; private set; }
        public string Distance { get; private set; }
        public string Velocity { get; private set; }
        public string Diameter { get; private set; }

        public RecentAsteroidModel(string name, string distance, string velocity, string diameter)
        {
            Name = name;
            Distance = distance;
            Velocity = velocity;
            Diameter = diameter;
        }
    }
}
