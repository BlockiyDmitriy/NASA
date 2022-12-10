using Nasa.Client.Models;
using Nasa.Data.Models.GetApodDTOs;

namespace Nasa.Client.MapperServices
{
    public static class Mapper
    {
        public static GetApodDataModel GetApodDtoToGetApodDataModel(GetApodDTO apod) =>
            new(Guid.NewGuid().ToString(), GetMediaTypes(apod.MediaType), apod.Copyright,
                    apod.Date, apod.HdUrl, apod.ServiceVersion, apod.Title, apod.Url, apod.Explanation, apod.ThumbnailUrl);



        private static MediaTypes GetMediaTypes(string? mediaType) => mediaType switch
        {
            "video" => MediaTypes.Video,
            "image" => MediaTypes.Image,
            _ => MediaTypes.None
        };
    }
}
