using Nasa.Client.Models;
using Nasa.Client.Services.HttpServices.RestServices;
using Nasa.Client.Services.LoggerServices;

namespace Nasa.Client.Services.DataServices.APODServices
{
    public class GetApodData : IGetApodData
    {
        private readonly IRestApiService _restApiService;
        private readonly ILogService _logService;

        public GetApodData(IRestApiService restApiService, ILogService logService)
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
                    apod.Date, apod.HdUrl, apod.ServiceVersion, apod.Title, apod.Url);

                return apodData;
            }
            catch (Exception e)
            {
                await _logService.TrackExceptionAsync(e, nameof(GetApodData), nameof(GetLastApod));
                return new GetApodDataModel(MediaTypes.None, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
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
