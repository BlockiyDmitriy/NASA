using Fluxor;
using Nasa.Client.Models;

namespace Nasa.Client.StateManagement.APOD.UseCases.ApodUseCase
{
    [FeatureState]
    public class CurrentApodCarouselState
    {
        public List<GetApodDataModel> CurrentApodData { get; }

        public CurrentApodCarouselState() { }

        public CurrentApodCarouselState(List<GetApodDataModel> currentApodMainData)
        {
            CurrentApodData = currentApodMainData;
        }
    }
}
