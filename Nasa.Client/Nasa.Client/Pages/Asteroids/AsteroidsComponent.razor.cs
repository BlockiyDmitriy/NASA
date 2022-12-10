namespace Nasa.Client.Pages.Asteroids
{
    public partial class AsteroidsComponent
    {
        protected override async Task OnInitializedAsync()
        {
            var t = await _asteroidService.GetRecentAsteroids();

            await base.OnInitializedAsync();
        }
    }
}
