using Nasa.Client.Models;
using Nasa.Client.Models.Asteroids;
using Nasa.Data.Models.AsteroidDTOs;
using Nasa.Data.Models.GetApodDTOs;

namespace Nasa.Client.MapperServices
{
    public static class Mapper
    {
        public static GetApodDataModel GetApodDtoToGetApodDataModel(GetApodDTO apod) =>
            new(Guid.NewGuid().ToString(), GetMediaTypes(apod.MediaType), apod.Copyright,
                    apod.Date, apod.HdUrl, apod.ServiceVersion, apod.Title, apod.Url, apod.Explanation, apod.ThumbnailUrl);

        internal static RecentAsteroidModel GetAsteroidDtoToRecentAsteroidModel(NearObjectDTO nearObjectDto) =>
            new(nearObjectDto.Name, nearObjectDto.EstimatedDiameter, nearObjectDto.CloseApproachData);

        private static MediaTypes GetMediaTypes(string? mediaType) => mediaType switch
        {
            "video" => MediaTypes.Video,
            "image" => MediaTypes.Image,
            _ => MediaTypes.None
        };
    }
}
