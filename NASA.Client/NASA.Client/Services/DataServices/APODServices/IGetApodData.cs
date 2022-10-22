using NASA.Data.Models;
using System.Threading.Tasks;

namespace NASA.Client.Services.DataServices.APODServices
{
    public interface IGetApodData
    {
        public Task<GetApodDTO> GetLastApod();
    }
}
