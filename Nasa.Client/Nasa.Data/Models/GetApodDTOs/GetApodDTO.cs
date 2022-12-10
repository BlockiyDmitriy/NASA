using System.Text.Json.Serialization;

namespace Nasa.Data.Models.GetApodDTOs
{
    public class GetApodDTO
    {
        [JsonPropertyName("copyright")]
        public string? Copyright { get; set; }
        [JsonPropertyName("date")]
        public string? Date { get; set; }
        [JsonPropertyName("hdurl")]
        public string? HdUrl { get; set; }
        [JsonPropertyName("media_type")]
        public string? MediaType { get; set; }
        [JsonPropertyName("service_version")]
        public string? ServiceVersion { get; set; }
        [JsonPropertyName("title")]
        public string? Title { get; set; }
        [JsonPropertyName("url")]
        public string? Url { get; set; }
        [JsonPropertyName("explanation")]
        public string? Explanation { get; set; }
        [JsonPropertyName("thumbnail_url")]
        public string? ThumbnailUrl { get; set; }

    }
}
