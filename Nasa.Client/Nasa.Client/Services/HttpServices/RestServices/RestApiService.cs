using Microsoft.Extensions.Configuration;
using Nasa.Client.Services.HttpServices.JsonServices;
using Nasa.Client.Services.LoggerServices;
using Nasa.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace Nasa.Client.Services.HttpServices.RestServices
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
                   .GetFromJsonAsync(APOD + $"?api_key={ApiKey}", _httpClient);

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
