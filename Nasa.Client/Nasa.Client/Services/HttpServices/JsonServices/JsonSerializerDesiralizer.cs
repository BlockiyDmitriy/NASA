using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace NASA.Client.Services.HttpServices.JsonServices
{
    public class JsonSerializerDesiralizer<T> where T : class
    {
        public static async Task<T> GetFromJsonAsync(string requestUrl, HttpClient httpClient)
        {
            return await httpClient.GetFromJsonAsync<T>(requestUrl);
        }
    }
}
