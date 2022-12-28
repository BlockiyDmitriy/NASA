using Nasa.Client.Models.Apod;

namespace Nasa.Client.Services.DataServices.APODServices
{
    public interface IGetApodDataService
    {
        //TODO: unused
        //public Task<GetApodDataModel> GetLastApod();

        public Task<List<GetApodDataModel>> GetApodByPeriod(DateTimeOffset fromDate, DateTimeOffset toDate);
        public Task<List<GetApodDataModel>> GetApodByCount(int count);
        public Task<List<GetApodDataModel>> GetApodByCountForCarousel(int count);
    }
}
