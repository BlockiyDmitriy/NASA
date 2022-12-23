using Fluxor;
using Nasa.Client.Models;
using Nasa.Client.Services.HttpServices.JsonServices;
using Nasa.Client.Services.LoggerServices;
using Nasa.Client.StateManagement.APOD.Actions;

namespace Nasa.Client.StateManagement.APOD.Services
{
    public class ApodStateService : IApodStateService
    {
        private readonly IDispatcher _dispatcher;

        private readonly ILogService _logService;

        public ApodStateService(ILogService logService, IDispatcher dispatcher)
        {
            _logService = logService;
            _dispatcher = dispatcher;
        }

        public async Task SetApodPeriodData(List<GetApodDataModel> model)
        {
            try
            {
                await _logService.LogAsync(string.Format("class: {0} => method: {1} => \n\t data: {2}",
                    this.GetType().Name, nameof(SetApodPeriodData), JsonSerializerDesiralizer<List<GetApodDataModel>>.SerializeData(model)));

                var action = new CurrentApodAction(model);

                _dispatcher.Dispatch(action);
            }
            catch (Exception e)
            {
                await _logService.TrackExceptionAsync(e, this.GetType().Name, nameof(SetApodPeriodData));
            }
        }

        public async Task SetApodRefreshedData(List<GetApodDataModel> model)
        {
            try
            {
                await _logService.LogAsync(string.Format("class: {0} => method: {1} => \n\t data: {2}",
                    this.GetType().Name, nameof(SetApodRefreshedData), JsonSerializerDesiralizer<List<GetApodDataModel>>.SerializeData(model)));

                var action = new CurrentApodRefreshedAction(model);

                _dispatcher.Dispatch(action);
            }
            catch (Exception e)
            {
                await _logService.TrackExceptionAsync(e, this.GetType().Name, nameof(SetApodRefreshedData));
            }
        }

        public async Task SetApodCarouselData(List<GetApodDataModel> model)
        {
            try
            {
                await _logService.LogAsync(string.Format("class: {0} => method: {1} => \n\t data: {2}",
                    this.GetType().Name, nameof(SetApodCarouselData), JsonSerializerDesiralizer<List<GetApodDataModel>>.SerializeData(model)));

                var action = new CurrentApodCarouselAction(model);

                _dispatcher.Dispatch(action);
            }
            catch (Exception e)
            {
                await _logService.TrackExceptionAsync(e, this.GetType().Name, nameof(SetApodCarouselData));
            }
        }
    }
}
