using Nasa.Client.Services.HttpServices.JsonServices;
using Nasa.Client.Services.LoggerServices;
using Nasa.Data.Models.GetApodDTOs;
using System.Reflection;

namespace Nasa.Client.Services.HttpServices.RestServices
{
    public class RestApiService : BaseHttpService, IRestApiService
    {
        public RestApiService(ILogService logService, IConfiguration configuration, HttpClient httpClient) :
            base(logService, configuration, httpClient)
        {
        }

        public async Task<GetApodDTO> GetLastAPOD()
        {
            try
            {
                await _logService.LogAsync("Get last APOD");

                var apod = await JsonSerializerDesiralizer<GetApodDTO>
                   .GetFromJsonAsync(APOD + $"?api_key={ApiKey}", _httpClient);

                await _logService.LogAsync(string.Format("Response: {0}", JsonSerializerDesiralizer<GetApodDTO>.SerializeData(apod)));

                return apod ?? new GetApodDTO();
            }
            catch (Exception e)
            {
                await _logService.TrackExceptionAsync(e, MethodBase.GetCurrentMethod()?.Name);
                return new GetApodDTO();
            }
        }

        public async Task<IEnumerable<GetApodDTO>> GetApodByPeriod(DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            try
            {
                await _logService.LogAsync("Get APOD by period");

                await _logService.LogAsync(string.Format("Get APOD from {0} => to {1}", JsonSerializerDesiralizer<string>.SerializeData(fromDate.Date.ToString("yyyy-MM-dd")),
                    JsonSerializerDesiralizer<string>.SerializeData(toDate.Date.ToString("yyyy-MM-dd"))));

                var apod = await JsonSerializerDesiralizer<IEnumerable<GetApodDTO>>
                   .GetFromJsonAsync(APOD + $"?api_key={ApiKey}&start_date={fromDate.Date.ToString("yyyy-MM-dd")}&end_date={toDate.Date.ToString("yyyy-MM-dd")}", _httpClient);

                await _logService.LogAsync(string.Format("Response: {0}", JsonSerializerDesiralizer<IEnumerable<GetApodDTO>>.SerializeData(apod)));

                return apod ?? new List<GetApodDTO>();
            }
            catch (Exception e)
            {
                await _logService.TrackExceptionAsync(e, MethodBase.GetCurrentMethod()?.Name);
                return new List<GetApodDTO>();
            }
        }
        public async Task<IEnumerable<GetApodDTO>> GetApodByCount(int count)
        {
            try
            {
                await _logService.LogAsync("Get APOD by count");

                var apod = await JsonSerializerDesiralizer<IEnumerable<GetApodDTO>>
                   .GetFromJsonAsync(APOD + $"?api_key={ApiKey}&count={count}", _httpClient);

                await _logService.LogAsync(string.Format("Response: {0}", JsonSerializerDesiralizer<IEnumerable<GetApodDTO>>.SerializeData(apod)));

                return apod ?? new List<GetApodDTO>();
            }
            catch (Exception e)
            {
                await _logService.TrackExceptionAsync(e, MethodBase.GetCurrentMethod()?.Name);
                return new List<GetApodDTO>();
            }
        }
    }
}
