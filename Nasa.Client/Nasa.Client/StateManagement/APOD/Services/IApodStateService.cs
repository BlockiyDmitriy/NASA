using Nasa.Client.Models.Apod;

namespace Nasa.Client.StateManagement.APOD.Services
{
    public interface IApodStateService
    {
        public Task SetApodPeriodData(List<GetApodDataModel> model);
        public Task SetApodRefreshedData(List<GetApodDataModel> model);
        public Task SetApodCarouselData(List<GetApodDataModel> model);
    }
}
