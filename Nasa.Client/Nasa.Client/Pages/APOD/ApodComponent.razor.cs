namespace Nasa.Client.Pages.APOD
{
    public partial class ApodComponent
    {
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            var apod = await _getApodDataService.GetLastApod();
        }
    }
}
