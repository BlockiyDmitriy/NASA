using Nasa.Client.Services.HttpServices.JsonServices;
using Nasa.Client.Services.LoggerServices;
using Nasa.Data.Models.AsteroidDTOs;
using Nasa.Data.Models.GetApodDTOs;
using System.Runtime.Serialization.Json;
using System.Text.Json;

namespace Nasa.Client.Services.HttpServices.RestServices
{
    public class RestApiService : BaseHttpService, IRestApiService
    {
        public RestApiService(ILogService logService, IConfiguration configuration, HttpClient httpClient) :
            base(logService, configuration, httpClient)
        {
        }

        #region APOD

        public async Task<GetApodDTO> GetLastAPOD()
        {
            try
            {
                await _logService.LogAsync(nameof(GetLastAPOD));

                var response = await _httpClient.GetAsync(APOD + $"?api_key={ApiKey}");

                await _logService.TrackResponseAsync(response);

                var result = await JsonSerializerDesiralizer<GetApodDTO>.GetFromResponseMessage(response);

                return result ?? new GetApodDTO();
            }
            catch (Exception e)
            {
                await _logService.TrackExceptionAsync(e, this.GetType().FullName, nameof(GetLastAPOD));
                return new GetApodDTO();
            }
        }

        public async Task<IEnumerable<GetApodDTO>> GetApodByPeriod(DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            try
            {
                await _logService.LogAsync(nameof(GetApodByPeriod));

                var response = await _httpClient.GetAsync(APOD + $"?api_key={ApiKey}&start_date={fromDate.Date.ToString("yyyy-MM-dd")}&end_date={toDate.Date.ToString("yyyy-MM-dd")}");

                await _logService.TrackResponseAsync(response);

                var result = await JsonSerializerDesiralizer<IEnumerable<GetApodDTO>>.GetFromResponseMessage(response);

                return result ?? new List<GetApodDTO>();
            }
            catch (Exception e)
            {
                await _logService.TrackExceptionAsync(e, this.GetType().FullName, nameof(GetApodByPeriod));
                return new List<GetApodDTO>();
            }
        }
        public async Task<IEnumerable<GetApodDTO>> GetApodByCount(int count)
        {
            try
            {
                await _logService.LogAsync(nameof(GetApodByCount));

                var response = await _httpClient.GetAsync(APOD + $"?api_key={ApiKey}&count={count}");

                await _logService.TrackResponseAsync(response);

                var result = await JsonSerializerDesiralizer<IEnumerable<GetApodDTO>>.GetFromResponseMessage(response);

                return result ?? new List<GetApodDTO>();
            }
            catch (Exception e)
            {
                await _logService.TrackExceptionAsync(e, this.GetType().FullName, nameof(GetApodByCount));
                return new List<GetApodDTO>();
            }
        }

        #endregion APOD

        #region Asteroid

        public async Task<GetAsteroidDTO> GetRecentAsteroids(DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            try
            {
                var response = await _httpClient.GetAsync(NEOFeed + $"?start_date={fromDate.Date.ToString("yyyy-MM-dd")}&end_date={toDate.Date.ToString("yyyy-MM-dd")}&api_key={ApiKey}");

                await _logService.TrackResponseAsync(response);

                //var settings = new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true };
                //var serializer = new DataContractJsonSerializer(typeof(RootObject), settings);

                var result = await JsonSerializerDesiralizer<GetAsteroidDTO>.GetFromResponseMessage(response);

                return result ?? new GetAsteroidDTO();
            }
            catch (Exception e)
            {
                await _logService.TrackExceptionAsync(e, this.GetType().FullName, nameof(GetRecentAsteroids));
                return new GetAsteroidDTO();
            }
        }

        public async Task<GetAsteroidDTO> GetUpcomingAsteroids()
        {
            throw new NotImplementedException();
        }

        public async Task<GetAsteroidDTO> GetImpactRiskAsteroids()
        {
            throw new NotImplementedException();
        }

        #endregion Asteroid
    }
}
