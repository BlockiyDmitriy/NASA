using Fluxor;
using Nasa.Client.Models.Apod;

namespace Nasa.Client.StateManagement.APOD.UseCases.ApodUseCase
{
    [FeatureState]
    public class CurrentApodRefreshedState
    {
        public List<GetApodDataModel>? CurrentApodRefreshedData { get; }

        public CurrentApodRefreshedState() { }
        public CurrentApodRefreshedState(List<GetApodDataModel>? currentApodRefreshedData)
        {
            CurrentApodRefreshedData = currentApodRefreshedData;
        }
    }
}
