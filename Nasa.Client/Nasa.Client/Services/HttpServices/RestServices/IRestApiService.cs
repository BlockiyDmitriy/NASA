using Nasa.Data.Models;
using System.Threading.Tasks;

namespace Nasa.Client.Services.HttpServices.RestServices
{
    public interface IRestApiService
    {
        public Task<GetApodDTO> GetLastAPOD(); 
    }
}
