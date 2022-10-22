using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NASA.Client.Services.LoggerServices
{
    public interface ILogService
    {
        public Task LogAsync(string message);
        public Task TrackExceptionAsync(Exception e, string? methodName);
        public Task TrackExceptionAsync(Exception e, string? className = null, string? procName = null);
        public Task TrackResponseAsync(HttpResponseMessage response);
    }
}
