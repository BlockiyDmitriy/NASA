using Nasa.Client.Models;
using Nasa.Client.StateManagement.APOD.UseCases.ApodUseCase;

namespace Nasa.Client.StateManagement.APOD.Actions
{
    public class CurrentApodAction
    {
        public List<GetApodDataModel>? CurrentApodData { get; }
        public List<GetApodDataModel>? CurrentApodRefreshedData { get; }

        public CurrentApodAction(List<GetApodDataModel>? currentApodMainData, List<GetApodDataModel>? currentApodRefreshedData)
        {
            CurrentApodData = currentApodMainData;
            CurrentApodRefreshedData = currentApodRefreshedData;
        }
    }
}
