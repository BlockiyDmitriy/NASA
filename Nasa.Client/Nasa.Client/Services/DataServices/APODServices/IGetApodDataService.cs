using Nasa.Client.Models;

namespace Nasa.Client.Services.DataServices.APODServices
{
    public interface IGetApodDataService
    {
        public Task<GetApodDataModel> GetLastApod();
        public Task<GetApodDataModel> GetApodByDate(DateTimeOffset date);
    }
}
