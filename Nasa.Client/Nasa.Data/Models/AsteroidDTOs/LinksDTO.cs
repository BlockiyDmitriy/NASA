using System.Text.Json.Serialization;

namespace Nasa.Data.Models.AsteroidDTOs
{
    public class LinksDTO
    {
        [JsonPropertyName("next")]
        public string? Next { get; set; }

        [JsonPropertyName("previous")]
        public string? Previous { get; set; }

        [JsonPropertyName("self")]
        public string? Self { get; set; }
    }
}
