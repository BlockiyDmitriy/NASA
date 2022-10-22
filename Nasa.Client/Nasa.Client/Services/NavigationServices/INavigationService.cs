using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nasa.Client.Services.NavigationServices
{
    public interface INavigationService
    {
        public Task NavigateToAsync(object navigationManager, string route);
    }
}
