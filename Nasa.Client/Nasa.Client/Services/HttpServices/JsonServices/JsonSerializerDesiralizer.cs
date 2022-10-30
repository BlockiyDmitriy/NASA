using System.Net.Http.Json;
using System.Text.Json;

namespace Nasa.Client.Services.HttpServices.JsonServices
{
    public class JsonSerializerDesiralizer<T> where T : class
    {
        public static async Task<T> GetFromJsonAsync(string requestUrl, HttpClient httpClient)
        {
            return await httpClient.GetFromJsonAsync<T>(requestUrl);
        }

        public static string SerializeData(T data)
        {
            return JsonSerializer.Serialize(data).ToString();
        }
    }
}
