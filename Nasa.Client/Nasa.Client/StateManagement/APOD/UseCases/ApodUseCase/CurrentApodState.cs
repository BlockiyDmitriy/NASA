using Fluxor;
using Nasa.Client.Models;

namespace Nasa.Client.StateManagement.APOD.UseCases.ApodUseCase
{
    [FeatureState]
    public class CurrentApodState
    {
        public List<GetApodDataModel> CurrentApodData { get;  }
        public List<GetApodDataModel>? CurrentApodRefreshedData { get;  }

        // An empty ctor is needed for the state
        public CurrentApodState() { }
        public CurrentApodState(List<GetApodDataModel> currentApodMainData, List<GetApodDataModel>? currentApodRefreshedData)
        {
            CurrentApodData = currentApodMainData;
            CurrentApodRefreshedData = currentApodRefreshedData;
        }
    }
}
