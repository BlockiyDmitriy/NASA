using Microsoft.Extensions.Configuration;
using NASA.Client.Services.LoggerServices;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NASA.Client.Services.HttpServices
{
    public abstract class BaseHttpService
    {
        #region Uri

        #endregion 
        protected ILogService _logService { get; set; }
        protected IConfiguration _configuration { get; set; }
        protected HttpClient _httpClient { get; set; }
        protected JsonSerializerOptions _options { get; set; }

        public BaseHttpService(ILogService logService, IConfiguration configuration, HttpClient httpClient)
        {
            _logService = logService;
            _configuration = configuration;

            _httpClient = httpClient;

            _options = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNameCaseInsensitive = true
            };

            InitUrlFromConfig();
        }
        private void InitUrlFromConfig()
        {
            GetCurrentCustomer = _configuration["Api:User:GetCurrentCustomer"];
        }
    }
}
