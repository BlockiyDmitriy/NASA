using Nasa.Client.Models.Apod;

namespace Nasa.Client.StateManagement.APOD.Actions
{
    public class CurrentApodRefreshedAction
    {
        public List<GetApodDataModel>? CurrentApodRefreshedData { get; }

        public CurrentApodRefreshedAction(List<GetApodDataModel>? currentApodRefreshedData)
        {
            CurrentApodRefreshedData = currentApodRefreshedData;
        }
    }
}
