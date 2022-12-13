using System.Text.Json.Serialization;

namespace Nasa.Data.Models.AsteroidDTOs
{
    public class GetAsteroidDTO
    {
        [JsonPropertyName("links")]
        public LinksDTO Links { get; set; }

        [JsonPropertyName("element_count")]
        public int ElementCount { get; set; }

        [JsonPropertyName("near_earth_objects")]
        public IDictionary<string, IEnumerable<NearObjectDTO>> NearObject { get; set; }
    }

    public class NearObjectDTO
    {
        [JsonPropertyName("links")]
        public LinksDTO? Links { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("neo_reference_id")]
        public string? NeoReferenceId { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("nasa_jpl_url")]
        public string? NasaJplUrl { get; set; }

        [JsonPropertyName("absolute_magnitude_h")]
        public double? AbsoluteMagnitudeH { get; set; }

        [JsonPropertyName("estimated_diameter")]
        public EstimatedDiameterDTO? EstimatedDiameter { get; set; }

        [JsonPropertyName("is_potentially_hazardous_asteroid")]
        public bool? IsPotentiallyHazardousAsteroid { get; set; }

        [JsonPropertyName("close_approach_data")]
        public List<CloseApproachDatumDTO>? CloseApproachData { get; set; }

        [JsonPropertyName("is_sentry_object")]
        public bool? IsSentryObject { get; set; }
    }
}