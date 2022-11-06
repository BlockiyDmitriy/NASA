using Nasa.Client.Models;

namespace Nasa.Client.Services.DataServices.APODServices
{
    public interface IGetApodDataService
    {
        public Task<GetApodDataModel> GetLastApod();
        public Task<List<GetApodDataModel>> GetApodByPeriod(DateTimeOffset fromDate, DateTimeOffset toDate);
        public Task<List<GetApodDataModel>> GetApodByCount(int count);
    }
}
