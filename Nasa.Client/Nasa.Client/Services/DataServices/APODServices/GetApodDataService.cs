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

        public async Task<List<GetApodDataModel>> GetApodByPeriod(DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            try
            {
                await _logService.LogAsync(nameof(GetApodByPeriod));

                var apodList = await _restApiService.GetApodByPeriod(fromDate, toDate);

                var apodData = new List<GetApodDataModel>();

                foreach (var apod in apodList)
                {
                    apodData.Add(new GetApodDataModel(GetMediaTypes(apod.MediaType), apod.Copyright,
                    apod.Date, apod.HdUrl, apod.ServiceVersion, apod.Title, apod.Url, apod.Explanation, apod.ThumbnailUrl));
                }

                return apodData;
            }
            catch (Exception e)
            {
                await _logService.TrackExceptionAsync(e, nameof(GetApodDataService), nameof(GetLastApod));

                return new List<GetApodDataModel>();
            }
        }
        public async Task<List<GetApodDataModel>> GetApodByCount(int count)
        {
            try
            {
                await _logService.LogAsync(nameof(GetApodByCount));

                var apodList = await _restApiService.GetApodByCount(count);

                var apodData = new List<GetApodDataModel>();

                foreach (var apod in apodList)
                {
                    apodData.Add(new GetApodDataModel(GetMediaTypes(apod.MediaType), apod.Copyright,
                    apod.Date, apod.HdUrl, apod.ServiceVersion, apod.Title, apod.Url, apod.Explanation, apod.ThumbnailUrl));
                }

                return apodData;
            }
            catch (Exception e)
            {
                await _logService.TrackExceptionAsync(e, nameof(GetApodDataService), nameof(GetLastApod));

                return new List<GetApodDataModel>();
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
