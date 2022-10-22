using NASA.Data.Models;
using System.Threading.Tasks;

namespace NASA.Client.Services.HttpServices.RestServices
{
    public interface IRestApiService
    {
        public Task<GetApodDTO> GetLastAPOD(); 
    }
}
