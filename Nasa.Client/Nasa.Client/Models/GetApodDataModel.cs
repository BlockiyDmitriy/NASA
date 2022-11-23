using System.Text.Json.Serialization;

namespace Nasa.Client.Models
{
    public class GetApodDataModel
    {
        public string Id { get; set; }
        public MediaTypes MediaTypes { get; private set; } = MediaTypes.None;
        public string? Copyright { get; private set; }
        public string? Date { get; private set; }
        public string? HdUrl { get; private set; }
        public string? ServiceVersion { get; private set; }
        public string? Title { get; private set; }
        public string? Url { get; private set; }
        public string? Explanation { get; private set; }
        public string? ThumbnailUrl { get; private set; }

        public GetApodDataModel(string id, MediaTypes mediaTypes, string? copyright, string? date, string? hdUrl, string? serviceVersion, string? title, string? url,
            string? explanation, string? thumbnailUrl)
        {
            Id = id;
            MediaTypes = mediaTypes;
            Copyright = copyright;
            Date = date;
            HdUrl = hdUrl;
            ServiceVersion = serviceVersion;
            Title = title;
            Url = url;
            Explanation = explanation;
            ThumbnailUrl = thumbnailUrl;
        }
    }
    
    public enum MediaTypes
    {
        None,
        Video,
        Image,
    }
}
