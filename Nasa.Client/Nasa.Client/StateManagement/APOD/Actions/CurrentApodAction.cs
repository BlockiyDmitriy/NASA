using Nasa.Client.Models.Apod;
using Nasa.Client.StateManagement.APOD.UseCases.ApodUseCase;

namespace Nasa.Client.StateManagement.APOD.Actions
{
    public class CurrentApodAction
    {
        public List<GetApodDataModel> CurrentApodData { get; }

        public CurrentApodAction(List<GetApodDataModel> currentApodMainData)
        {
            CurrentApodData = currentApodMainData;
        }
    }
}
