using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.DataLayer.EntityModels;
using BookingSystem.DataLayer.Interfaces;
using System.Threading.Tasks;


namespace BookingSystem.BusinessLogic.Services
{
    public class OpenAirBLService : IBusinessLayerCRUDServiceAsync<OpenAirBL>
    {
        IRepositoryAsync<OpenAir> _repository;
        IMapper<OpenAir, OpenAirBL> _mapperToOpenAirBLEvents;
        IMapper<OpenAirBL, OpenAir> _mapperFromOpenAirBLEvents;

        public OpenAirBLService
            (
            IRepositoryAsync<OpenAir> repository,
            IMapper<OpenAir, OpenAirBL> mapperToOpenAirBLEvents,
            IMapper<OpenAirBL, OpenAir> mapperFromOpenAirBLEvents)
        {
            _repository = repository;
            _mapperToOpenAirBLEvents = mapperToOpenAirBLEvents;
            _mapperFromOpenAirBLEvents = mapperFromOpenAirBLEvents;
        }
        public async Task CreateAsync(OpenAirBL openAirArtEvevnt)
        {
            await _repository.CreateAsync(_mapperFromOpenAirBLEvents.Map(openAirArtEvevnt));
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<PagedList<OpenAirBL>> GetAllAsync(PagesState pagesStatus)
        {
            PagesState _pagesStatus;
            _pagesStatus = pagesStatus ?? new PagesState();

            var pagedResult = await PagedList<OpenAir>.TakePagedListAsync(_repository.GetAll(), pagesStatus.PageNumber, pagesStatus.PageSize);
            return pagedResult.MapTo(_mapperToOpenAirBLEvents);
        }

        public async Task<OpenAirBL> GetAsync(int id)
        {
            return _mapperToOpenAirBLEvents.Map(await _repository.GetAsync(id));
        }

        public async Task UpdateAsync(OpenAirBL openAirArtEvevnt)
        {
            await _repository.UpdateAsync(_mapperFromOpenAirBLEvents.Map(openAirArtEvevnt));
        }
    }
}
