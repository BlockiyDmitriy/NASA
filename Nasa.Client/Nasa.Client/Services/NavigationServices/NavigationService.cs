using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Nasa.Client.Services.NavigationServices
{
    public class NavigationService : INavigationService
    {
        private NavigationManager _navigation;

        public Task NavigateToAsync(object navigationObject, string route)
        {
            if (navigationObject is NavigationManager navigationManager)
            {
                _navigation = navigationManager;
            }
            _navigation.NavigateTo(route);
            return Task.CompletedTask;
        }
    }
}
