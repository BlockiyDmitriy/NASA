using System.Text.Json.Serialization;

namespace Nasa.Data.Models.AsteroidDTOs
{
    public class EstimatedDiameterDTO
    {
        [JsonPropertyName("kilometers")]
        public KilometersDTO? Kilometers { get; set; }

        [JsonPropertyName("meters")]
        public MetersDTO? Meters { get; set; }

        [JsonPropertyName("miles")]
        public MilesDTO? Miles { get; set; }

        [JsonPropertyName("feet")]
        public FeetDTO? Feet { get; set; }
    }

    public class FeetDTO
    {
        [JsonPropertyName("estimated_diameter_min")]
        public double? EstimatedDiameterMin { get; set; }

        [JsonPropertyName("estimated_diameter_max")]
        public double? EstimatedDiameterMax { get; set; }
    }

    public class KilometersDTO
    {
        [JsonPropertyName("estimated_diameter_min")]
        public double? EstimatedDiameterMin { get; set; }

        [JsonPropertyName("estimated_diameter_max")]
        public double? EstimatedDiameterMax { get; set; }
    }

    public class MetersDTO
    {
        [JsonPropertyName("estimated_diameter_min")]
        public double? EstimatedDiameterMin { get; set; }

        [JsonPropertyName("estimated_diameter_max")]
        public double? EstimatedDiameterMax { get; set; }
    }

    public class MilesDTO
    {
        [JsonPropertyName("estimated_diameter_min")]
        public double? EstimatedDiameterMin { get; set; }

        [JsonPropertyName("estimated_diameter_max")]
        public double? EstimatedDiameterMax { get; set; }
    }
}
