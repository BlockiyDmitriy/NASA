using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Nasa.Data.Models
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
    }
}
