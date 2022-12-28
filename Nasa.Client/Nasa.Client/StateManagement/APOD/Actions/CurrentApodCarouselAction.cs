using Nasa.Client.Models.Apod;

namespace Nasa.Client.StateManagement.APOD.Actions
{
    public class CurrentApodCarouselAction
    {
        public List<GetApodDataModel> CurrentApodData { get; }

        public CurrentApodCarouselAction(List<GetApodDataModel> currentApodMainData)
        {
            CurrentApodData = currentApodMainData;
        }
    }
}
