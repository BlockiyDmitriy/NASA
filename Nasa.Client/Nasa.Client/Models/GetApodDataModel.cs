namespace Nasa.Client.Models
{
    public class GetApodDataModel
    {
        public MediaTypes MediaTypes { get; private set; } = MediaTypes.None;
        public string? Copyright { get; private set; }
        public string? Date { get; private set; }
        public string? HdUrl { get; private set; }
        public string? ServiceVersion { get; private set; }
        public string? Title { get; private set; }
        public string? Url { get; private set; }

        public GetApodDataModel(MediaTypes mediaTypes, string? copyright, string? date, string? hdUrl, string? serviceVersion, string? title, string? url)
        {
            MediaTypes = mediaTypes;
            Copyright = copyright;
            Date = date;
            HdUrl = hdUrl;
            ServiceVersion = serviceVersion;
            Title = title;
            Url = url;
        }
    }
    
    public enum MediaTypes
    {
        None,
        Video,
        Image,
    }
}
