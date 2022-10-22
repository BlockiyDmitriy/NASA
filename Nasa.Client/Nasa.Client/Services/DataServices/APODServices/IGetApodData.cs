using Nasa.Data.Models;
using System.Threading.Tasks;

namespace Nasa.Client.Services.DataServices.APODServices
{
    public interface IGetApodData
    {
        public Task<GetApodDTO> GetLastApod();
    }
}
