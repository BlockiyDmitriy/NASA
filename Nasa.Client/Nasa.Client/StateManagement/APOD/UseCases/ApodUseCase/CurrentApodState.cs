using Fluxor;
using Nasa.Client.Models.Apod;

namespace Nasa.Client.StateManagement.APOD.UseCases.ApodUseCase
{
    [FeatureState]
    public class CurrentApodState
    {
        public List<GetApodDataModel> CurrentApodData { get;  }

        // An empty ctor is needed for the state
        public CurrentApodState() { }
        public CurrentApodState(List<GetApodDataModel> currentApodMainData)
        {
            CurrentApodData = currentApodMainData;
        }
    }
}
