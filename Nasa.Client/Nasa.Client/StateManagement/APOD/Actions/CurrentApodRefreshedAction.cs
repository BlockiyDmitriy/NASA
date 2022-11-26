using Nasa.Client.Models;

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
