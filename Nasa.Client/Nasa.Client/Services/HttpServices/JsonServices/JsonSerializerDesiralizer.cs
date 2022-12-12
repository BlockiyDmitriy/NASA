using System.Net.Http.Json;
using System.Text.Json;

namespace Nasa.Client.Services.HttpServices.JsonServices
{
    public class JsonSerializerDesiralizer<T> where T : class
    {        
        public static async Task<T> GetFromResponseMessage(HttpResponseMessage httpResponseMessage)
        {
            var options = new JsonSerializerOptions()
            {
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            return await httpResponseMessage.Content.ReadFromJsonAsync<T>(options);
        }

        public static string SerializeData(T data)
        {
            return JsonSerializer.Serialize(data).ToString();
        }
    }
}
