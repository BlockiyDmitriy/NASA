using Nasa.Data.Models;
using System.Threading.Tasks;

namespace Nasa.Client.Services.HttpServices.RestServices
{
    public interface IRestApiService
    {
        public Task<GetApodDTO> GetLastAPOD(); 
        public Task<IEnumerable<GetApodDTO>> GetApodByPeriod(DateTimeOffset fromDate, DateTimeOffset toDate); 
        public Task<IEnumerable<GetApodDTO>> GetApodByCount(int count); 
    }
}
