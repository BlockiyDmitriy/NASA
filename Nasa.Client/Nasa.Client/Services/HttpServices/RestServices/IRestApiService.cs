using Nasa.Data.Models.AsteroidDTOs;
using Nasa.Data.Models.GetApodDTOs;

namespace Nasa.Client.Services.HttpServices.RestServices
{
    public interface IRestApiService
    {
        #region APOD

        public Task<GetApodDTO> GetLastAPOD(); 
        public Task<IEnumerable<GetApodDTO>> GetApodByPeriod(DateTimeOffset fromDate, DateTimeOffset toDate); 
        public Task<IEnumerable<GetApodDTO>> GetApodByCount(int count);

        #endregion APOD

        #region Asteroid

        public Task<IEnumerable<GetAsteroidDTO>> GetRecentAsteroids(DateTimeOffset fromDate, DateTimeOffset toDate);
        public Task<IEnumerable<GetAsteroidDTO>> GetUpcomingAsteroids();
        public Task<IEnumerable<GetAsteroidDTO>> GetImpactRiskAsteroids();

        #endregion Asteroid
    }
}
