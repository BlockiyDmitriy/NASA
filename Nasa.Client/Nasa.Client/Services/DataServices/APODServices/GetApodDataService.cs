using Nasa.Client.Models;
using Nasa.Client.Services.HttpServices.RestServices;
using Nasa.Client.Services.LoggerServices;

namespace Nasa.Client.Services.DataServices.APODServices
{
    public class GetApodDataService : IGetApodDataService
    {
        private readonly IRestApiService _restApiService;
        private readonly ILogService _logService;

        public GetApodDataService(IRestApiService restApiService, ILogService logService)
        {
            _logService = logService;
            _restApiService = restApiService;
        }

        public async Task<GetApodDataModel> GetLastApod()
        {
            try
            {
                await _logService.LogAsync(nameof(GetLastApod));

                var apod = await _restApiService.GetLastAPOD();

                var apodData = new GetApodDataModel(GetMediaTypes(apod.MediaType), apod.Copyright,
                    apod.Date, apod.HdUrl, apod.ServiceVersion, apod.Title, apod.Url, apod.Explanation, apod.ThumbnailUrl);

                return apodData;
            }
            catch (Exception e)
            {
                await _logService.TrackExceptionAsync(e, nameof(GetApodDataService), nameof(GetLastApod));

                return new GetApodDataModel(MediaTypes.None, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 
                    string.Empty, string.Empty, string.Empty);
            }
        }

        public async Task<GetApodDataModel> GetApodByDate(DateTimeOffset date)
        {
            try
            {
                await _logService.LogAsync(nameof(GetApodByDate));

                var apod = await _restApiService.GetApodByDate(date);

                var apodData = new GetApodDataModel(GetMediaTypes(apod.MediaType), apod.Copyright,
                    apod.Date, apod.HdUrl, apod.ServiceVersion, apod.Title, apod.Url, apod.Explanation, apod.ThumbnailUrl);

                return apodData;
            }
            catch (Exception e)
            {
                await _logService.TrackExceptionAsync(e, nameof(GetApodDataService), nameof(GetLastApod));

                return new GetApodDataModel(MediaTypes.None, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                    string.Empty, string.Empty, string.Empty);
            }
        }
        private static MediaTypes GetMediaTypes(string? mediaType) => mediaType switch
        {
            "video" => MediaTypes.Video,
            "image" => MediaTypes.Image,
            _ => MediaTypes.None
        };

    }
}
