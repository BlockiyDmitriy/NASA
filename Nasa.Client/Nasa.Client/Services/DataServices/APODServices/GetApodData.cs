using NASA.Client.Services.HttpServices.RestServices;
using NASA.Client.Services.LoggerServices;
using NASA.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace NASA.Client.Services.DataServices.APODServices
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

        public async Task<GetApodDTO> GetLastApod()
        {
            try
            {
                await _logService.LogAsync(nameof(GetLastApod));

                var apod = await _restApiService.GetLastAPOD();

                return apod;
            }
            catch (Exception e)
            {
                await _logService.TrackExceptionAsync(e, nameof(GetApodData), nameof(GetLastApod));
                return new GetApodDTO();
            }
        }
    }
}
