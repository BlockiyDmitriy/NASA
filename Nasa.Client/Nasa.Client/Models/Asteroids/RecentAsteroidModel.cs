using Nasa.Data.Models.AsteroidDTOs;

namespace Nasa.Client.Models.Asteroids
{
    public class RecentAsteroidModel
    {
        public string Name { get; private set; }
        public EstimatedDiameterDTO? EstimatedDiameter { get; set; }
        public IEnumerable<CloseApproachDatumDTO> CloseApproachData { get; set; }

        public RecentAsteroidModel(string name, EstimatedDiameterDTO? estimatedDiameter, IEnumerable<CloseApproachDatumDTO>  closeApproachData)
        {
            Name = name;
            EstimatedDiameter = estimatedDiameter;
            CloseApproachData = closeApproachData;
        }
    }
}
