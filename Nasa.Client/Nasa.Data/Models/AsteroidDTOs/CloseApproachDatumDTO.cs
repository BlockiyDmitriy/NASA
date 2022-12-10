using System.Text.Json.Serialization;

namespace Nasa.Data.Models.AsteroidDTOs
{
    public class CloseApproachDatumDTO
    {
        [JsonPropertyName("close_approach_date")]
        public string? CloseApproachDate { get; set; }

        [JsonPropertyName("close_approach_date_full")]
        public string? CloseApproachDateFull { get; set; }

        [JsonPropertyName("epoch_date_close_approach")]
        public object? EpochDateCloseApproach { get; set; }

        [JsonPropertyName("relative_velocity")]
        public RelativeVelocityDTO? RelativeVelocity { get; set; }

        [JsonPropertyName("miss_distance")]
        public MissDistanceDTO? MissDistance { get; set; }

        [JsonPropertyName("orbiting_body")]
        public string? OrbitingBody { get; set; }
    }
}
