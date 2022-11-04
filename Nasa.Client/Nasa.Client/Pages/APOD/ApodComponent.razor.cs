using Microsoft.JSInterop;
using MudBlazor;
using Nasa.Client.Models;
using Nasa.Client.Pages.APOD.Dialogs;

namespace Nasa.Client.Pages.APOD
{
    public partial class ApodComponent
    {
        public GetApodDataModel GetApodData { get; private set; }

        public ApodComponent()
        {
            GetApodData = new(MediaTypes.None, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
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

        private Task OnClickImage()
        {
            if (GetApodData.MediaTypes == MediaTypes.Image)
            {
                if (GetApodData.HdUrl is not null)
                {

                    var options = new DialogOptions { CloseOnEscapeKey = true, FullScreen = true, NoHeader=true };
                    var parameters = new DialogParameters { ["GetApodData"] = GetApodData };

                    _dialogService.Show<ImageApodDialog>(string.Empty, parameters, options);
                }
            }

            return Task.CompletedTask;
        }
    }
}
