﻿using Nasa.Client.Services.HttpServices.JsonServices;
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

                await _logService.LogAsync(string.Format("Request: {0}", JsonSerializerDesiralizer<GetApodDTO>.SerializeData(apod)));

                return apod ?? new GetApodDTO();
            }
            catch (Exception e)
            {
                await _logService.TrackExceptionAsync(e, MethodBase.GetCurrentMethod()?.Name);
                return new GetApodDTO();
            }
        }

        public async Task<GetApodDTO> GetApodByDate(DateTimeOffset date)
        {
            try
            {
                await _logService.LogAsync("Get APOD by date");

                var apod = await JsonSerializerDesiralizer<GetApodDTO>
                   .GetFromJsonAsync(APOD + $"?api_key={ApiKey}&date={date.Date}", _httpClient);

                await _logService.LogAsync(string.Format("Request: {0}", JsonSerializerDesiralizer<GetApodDTO>.SerializeData(apod)));

                return apod ?? new GetApodDTO();
            }
            catch (Exception e)
            {
                await _logService.TrackExceptionAsync(e, MethodBase.GetCurrentMethod()?.Name);
                return new GetApodDTO();
            }
        }
        public async Task<List<GetApodDTO>> GetApodByCount(int count)
        {
            try
            {
                await _logService.LogAsync("Get APOD by count");

                var apod = await JsonSerializerDesiralizer<List<GetApodDTO>>
                   .GetFromJsonAsync(APOD + $"?api_key={ApiKey}&count={count}", _httpClient);

                await _logService.LogAsync(string.Format("Request: {0}", JsonSerializerDesiralizer<List<GetApodDTO>>.SerializeData(apod)));

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
