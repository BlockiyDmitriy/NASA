using Microsoft.JSInterop;
using MudBlazor;
using Nasa.Client.Models;
using Nasa.Client.Pages.APOD.Dialogs;

namespace Nasa.Client.Pages.APOD
{
    public partial class ApodComponent
    {
        public GetApodDataModel GetApodData { get; private set; }
        public List<GetApodDataModel> ListRandomApod { get; private set; }
        public List<GetApodDataModel> ListLastApod { get; private set; }

        public ApodComponent()
        {
            GetApodData = new(MediaTypes.None, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
            ListRandomApod = new();
            ListLastApod = new();
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            await LoadData();
            await LoadLastFiveData();
        }

        private async Task LoadData()
        {
            GetApodData = await _getApodDataService.GetLastApod();

            if (GetApodData.MediaTypes == MediaTypes.Video)
            {
                await _jsRuntime.InvokeVoidAsync("videoControls.playVideo", GetApodData.Url);
            }
        }

        private async Task LoadLastFiveData()
        {
            var listData = await _getApodDataService.GetApodByPeriod(DateTimeOffset.UtcNow.AddDays(-6).Date, DateTimeOffset.UtcNow.AddDays(-1).Date);

            //foreach (var data in listData)
            //{
            //    if (data.MediaTypes == MediaTypes.Video)
            //    {
            //        await _jsRuntime.InvokeVoidAsync("videoControls.playVideo", data.Url);
            //    }
            //}
            listData = listData.OrderByDescending(a => a.Date).ToList();

            ListLastApod = listData;
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

                var newDataList = await _getApodDataService.GetApodByCount(5);

                ListRandomApod = newDataList;
            }
            catch (Exception ex)
            {
                await _logService.TrackExceptionAsync(ex, this.GetType().ToString(), nameof(LoadMore));
            }
        }
    }
}
