using Microsoft.JSInterop;
using MudBlazor;
using Nasa.Client.Models;
using Nasa.Client.Pages.APOD.Dialogs;

namespace Nasa.Client.Pages.APOD
{
    public partial class ApodComponent
    {
        private string _loadMoreBtn = "Load more";

        protected override async Task OnInitializedAsync()
        {
            await LoadData();

            await base.OnInitializedAsync();

            await InvokeAsync(StateHasChanged);
        }

        private async Task LoadData()
        {
            _ = await _getApodDataService.GetApodByPeriod(DateTimeOffset.UtcNow.AddDays(-5).Date, DateTimeOffset.UtcNow.Date);

            // Mock data
            //var t = new GetApodDataModel(MediaTypes.Video, getApodData.Copyright, getApodData.Date, getApodData.HdUrl, getApodData.ServiceVersion,
            //    getApodData.Title, "https://www.youtube.com/embed/7dh5VL5YGoA?rel=0", getApodData.Explanation, null);
        }

        private Task OnClickImage(GetApodDataModel selectedApod)
        {
            if (selectedApod.MediaTypes == MediaTypes.Image)
            {
                if (selectedApod.HdUrl is not null)
                {

                    var options = new DialogOptions { CloseOnEscapeKey = true, FullScreen = true, NoHeader = true };
                    var parameters = new DialogParameters { ["GetApodData"] = selectedApod };

                    _dialogService.Show<ImageApodDialog>(string.Empty, parameters, options);
                }
            }

            return Task.CompletedTask;
        }

        private async Task LoadMore()
        {
            try
            {
                await _logService.LogAsync("Load more APOD");

                if (_apodRefreshedState?.Value.CurrentApodRefreshedData is not null && _apodRefreshedState.Value.CurrentApodRefreshedData.Any())
                {
                    var position = await _jsRuntime.InvokeAsync<string>("ScrollToElement", "apodContent");
                }

                var res = await _getApodDataService.GetApodByCount(6);
                if (res.Any())
                {
                    _loadMoreBtn = "Refresh";
                }
            }
            catch (Exception ex)
            {
                await _logService.TrackExceptionAsync(ex, this.GetType().ToString(), nameof(LoadMore));
            }
        }
    }
}
