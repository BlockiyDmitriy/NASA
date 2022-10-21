using Microsoft.Extensions.Configuration;
using NASA.Client.Services.HttpServices.JsonServices;
using NASA.Client.Services.LoggerServices;
using NASA.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace NASA.Client.Services.HttpServices.RestServices
{
    public class RestApiService : BaseHttpService, IRestApiService
    {
        public RestApiService(ILogService logService, IConfiguration configuration, HttpClient httpClient) : base(logService, configuration, httpClient)
        {
        }

        public async Task<GetApodDTO> GetLastAPOD()
        {
            try
            {
                await _logService.LogAsync("Get last APOD");

                var apod = await JsonSerializerDesiralizer<GetApodDTO>
                   .GetFromJsonAsync(APOD, _httpClient);
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
