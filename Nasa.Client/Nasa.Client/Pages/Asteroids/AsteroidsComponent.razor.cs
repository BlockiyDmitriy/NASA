namespace Nasa.Client.Pages.Asteroids
{
    public partial class AsteroidsComponent
    {
        protected override async Task OnInitializedAsync()
        {
            _ = await _asteroidService.GetRecentAsteroids();

            await base.OnInitializedAsync();
        }
    }
}
