using System.Text.Json.Serialization;

namespace Nasa.Data.Models.AsteroidDTOs
{
    public class MissDistanceDTO
    {
        [JsonPropertyName("astronomical")]
        public string? Astronomical { get; set; }

        [JsonPropertyName("lunar")]
        public string? Lunar { get; set; }

        [JsonPropertyName("kilometers")]
        public string? Kilometers { get; set; }

        [JsonPropertyName("miles")]
        public string? Miles { get; set; }
    }
}
