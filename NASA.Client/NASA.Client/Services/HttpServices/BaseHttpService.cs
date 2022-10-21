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

        protected string ApiKey { get; private set; }

        protected string APOD { get; private set; }

        protected string NEOFeed { get; private set; }
        protected string NEOLookup { get; private set; }
        protected string NEOBrowser { get; private set; }


        #endregion 
        protected ILogService _logService { get; private set; }
        protected IConfiguration _configuration { get; private set; }
        protected HttpClient _httpClient { get; private set; }

        public BaseHttpService(ILogService logService, IConfiguration configuration, HttpClient httpClient)
        {
            _logService = logService;
            _configuration = configuration;

            _httpClient = httpClient;

            InitUrlFromConfig();
        }
        private void InitUrlFromConfig()
        {
            ApiKey = _configuration["Api:ApiKey"];

            APOD = _configuration["Api:APOD:APOD"];

            NEOFeed = _configuration["Api:NEO:Feed"];
            NEOLookup = _configuration["Api:NEO:Lookup"];
            NEOBrowser = _configuration["Api:NEO:Browser"];

        }
    }
}
