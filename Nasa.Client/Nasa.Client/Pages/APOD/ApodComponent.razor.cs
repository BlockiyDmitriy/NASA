using Microsoft.JSInterop;
using Nasa.Client.Models;

namespace Nasa.Client.Pages.APOD
{
    public partial class ApodComponent
    {
        public GetApodDataModel GetApodData { get; private set; }

        public ApodComponent()
        {
            GetApodData = new(MediaTypes.None, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            await LoadData();
        }

        private async Task LoadData()
        {
            GetApodData = await _getApodDataService.GetLastApod();

            if (GetApodData.MediaTypes == MediaTypes.Video)
            {
                await _jsRuntime.InvokeVoidAsync("videoControls.playVideo", GetApodData.Url);
            }
        }
    }
}
