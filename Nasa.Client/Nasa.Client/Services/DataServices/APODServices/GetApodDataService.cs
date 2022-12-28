using Nasa.Client.MapperServices;
using Nasa.Client.Models.Apod;
using Nasa.Client.Services.HttpServices.RestServices;
using Nasa.Client.Services.LoggerServices;
using Nasa.Client.StateManagement.APOD.Services;

namespace Nasa.Client.Services.DataServices.APODServices
{
    public class GetApodDataService : IGetApodDataService
    {
        private readonly IRestApiService _restApiService;
        private readonly ILogService _logService;
        private readonly IApodStateService _apodStateService;

        public GetApodDataService(IRestApiService restApiService, ILogService logService, IApodStateService apodStateService)
        {
            _logService = logService;
            _restApiService = restApiService;
            _apodStateService = apodStateService;
        }

        //TODO: unused
        //public async Task<GetApodDataModel> GetLastApod()
        //{
        //    try
        //    {
        //        await _logService.LogAsync(nameof(GetLastApod));

        //        var apod = await _restApiService.GetLastAPOD();

        //        var apodData = new GetApodDataModel(Guid.NewGuid().ToString(), GetMediaTypes(apod.MediaType), apod.Copyright,
        //            apod.Date, apod.HdUrl, apod.ServiceVersion, apod.Title, apod.Url, apod.Explanation, apod.ThumbnailUrl);

        //        await _apodStateService.SetApod(apodData);

        //        return apodData;
        //    }
        //    catch (Exception e)
        //    {
        //        await _logService.TrackExceptionAsync(e, nameof(GetApodDataService), nameof(GetLastApod));

        //        return new GetApodDataModel(Guid.NewGuid().ToString(), MediaTypes.None, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 
        //            string.Empty, string.Empty, string.Empty);
        //    }
        //}

        public async Task<List<GetApodDataModel>> GetApodByPeriod(DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            try
            {
                await _logService.LogAsync(nameof(GetApodByPeriod));

                var apodList = await _restApiService.GetApodByPeriod(fromDate, toDate);

                var apodData = new List<GetApodDataModel>();

                foreach (var apod in apodList)
                {
                    apodData.Add(Mapper.GetApodDtoToGetApodDataModel(apod));
                }
                apodData = apodData.OrderByDescending(a => a.Date).ToList();

                await _apodStateService.SetApodPeriodData(apodData);

                return apodData;
            }
            catch (Exception e)
            {
                await _logService.TrackExceptionAsync(e, nameof(GetApodDataService), nameof(GetApodByPeriod));

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
                    apodData.Add(Mapper.GetApodDtoToGetApodDataModel(apod));
                }

                await _apodStateService.SetApodRefreshedData(apodData);

                return apodData;
            }
            catch (Exception e)
            {
                await _logService.TrackExceptionAsync(e, nameof(GetApodDataService), nameof(GetApodByCount));

                return new List<GetApodDataModel>();
            }
        }

        public async Task<List<GetApodDataModel>> GetApodByCountForCarousel(int count)
        {
            try
            {
                await _logService.LogAsync(nameof(GetApodByCountForCarousel));

                var apodList = await _restApiService.GetApodByCount(count);

                var apodData = new List<GetApodDataModel>();

                foreach (var apod in apodList)
                {
                    apodData.Add(Mapper.GetApodDtoToGetApodDataModel(apod));
                }

                await _apodStateService.SetApodCarouselData(apodData);

                return apodData;
            }
            catch (Exception e)
            {
                await _logService.TrackExceptionAsync(e, nameof(GetApodDataService), nameof(GetApodByCountForCarousel));

                return new List<GetApodDataModel>();
            }
        }
    }
}
