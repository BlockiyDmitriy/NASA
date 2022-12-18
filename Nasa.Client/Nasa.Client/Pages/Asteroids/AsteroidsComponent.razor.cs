namespace Nasa.Client.Pages.Asteroids
{
    public partial class AsteroidsComponent
    {
        private bool _open = false;

        protected override async Task OnInitializedAsync()
        {
            _ = await _asteroidService.GetRecentAsteroids();

            await base.OnInitializedAsync();
        }

        void ToggleDrawer()
        {
            _open = true;
        }
    }
}
