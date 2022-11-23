using Nasa.Client.Models;

namespace Nasa.Client.StateManagement.APOD.Services
{
    public interface IApodStateService
    {
        public Task SetApodPeriodData(List<GetApodDataModel> model);
        public Task SetApodRefreshedData(List<GetApodDataModel> model);
    }
}
