using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.DataLayer.EntityModels;
using BookingSystem.DataLayer.Interfaces;
using System.Threading.Tasks;
using System;
using AutoMapper;

namespace BookingSystem.BusinessLogic.Services.CRUDServices
{
    public class ArtEventCRUDService : BaseGenericCRUDArtEventService<ArtEventBL, ArtEvent>
    {
        private readonly IArtEventFilter<ArtEvent> _filter;
        private readonly IArtEventSort<ArtEvent> _sorter;
        public ArtEventCRUDService(
            IRepositoryAsync<ArtEvent> repository, 
            IMapper mapper,            
            IArtEventFilter<ArtEvent> artEventFilter,
            IArtEventSort<ArtEvent> artEventSorter
            ) : base(repository, mapper)
        {
            _filter = artEventFilter;
            _sorter = artEventSorter;
        }
        public override Task CreateAsync(ArtEventBL artEvevnt)
        {
            throw new NotImplementedException();
        }
        public override async Task<PagedList<ArtEventBL>> GetAllAsync(PagesState pagesStatus)
        {
            PagesState _pagesStatus;
            _pagesStatus = pagesStatus ?? new PagesState();

            var artEventsQuery = _repository.GetAll();
            artEventsQuery = _filter.FilterBy(artEventsQuery, pagesStatus);
            artEventsQuery = _sorter.SortBy(artEventsQuery, pagesStatus.SortBy);

            var pagedArtEvents = await PagedList<ArtEvent>.TakePagedListAsync(artEventsQuery, pagesStatus.PageNumber, pagesStatus.PageSize);

            return pagedArtEvents.MapTo<ArtEventBL>(_mapper);
        }
        public override Task UpdateAsync(ArtEventBL artEvevnt)
        {
            throw new NotImplementedException();
        }
    }
}
