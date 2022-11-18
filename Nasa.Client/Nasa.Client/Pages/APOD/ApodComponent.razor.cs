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

        private string _loadMoreBtn = "Load more";

        public ApodComponent()
        {
            GetApodData = new(MediaTypes.None, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                string.Empty, string.Empty, string.Empty);
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

            // Mock data
            //var t = new GetApodDataModel(MediaTypes.Video, getApodData.Copyright, getApodData.Date, getApodData.HdUrl, getApodData.ServiceVersion,
            //    getApodData.Title, "https://www.youtube.com/embed/7dh5VL5YGoA?rel=0", getApodData.Explanation, null);
        }

        private async Task LoadLastFiveData()
        {
            var listData = await _getApodDataService.GetApodByPeriod(DateTimeOffset.UtcNow.AddDays(-6).Date, DateTimeOffset.UtcNow.AddDays(-1).Date);
            
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

                if (ListRandomApod.Any())
                {
                    var position = await _jsRuntime.InvokeAsync<string>("ScrollToElement", "apodContent");
                }

                var newDataList = await _getApodDataService.GetApodByCount(5);
                
                _loadMoreBtn = "Refresh";

                ListRandomApod = newDataList;
            }
            catch (Exception ex)
            {
                await _logService.TrackExceptionAsync(ex, this.GetType().ToString(), nameof(LoadMore));
            }
        }
    }
}
