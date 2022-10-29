using Nasa.Client.Services.HttpServices.JsonServices;
using Nasa.Client.Services.LoggerServices;
using Nasa.Data.Models;
using System.Reflection;
using System.Text.Json;

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

                await _logService.LogAsync(string.Format("Request: {0}", JsonSerializer.Serialize(apod).ToString()));

                return apod;
            }
            catch (Exception e)
            {
                await _logService.TrackExceptionAsync(e, MethodBase.GetCurrentMethod()?.Name);
                return new GetApodDTO();
            }
        }
    }
}
