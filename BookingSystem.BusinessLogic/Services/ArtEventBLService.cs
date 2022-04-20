using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.DataLayer;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.BusinessLogic.Services;
using BookingSystem.DataLayer.EntityModels;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.DataLayer.EntityFramework.Repository;
using Microsoft.EntityFrameworkCore;
using BookingSystem.DataLayer.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BookingSystem.BusinessLogic.Services
{
    public class ArtEventBLService : IBusinessLayerCRUDServiceAsync<ArtEventBL>
    {
        IRepositoryAsync<ArtEvent> _repository;
        IMapper<ArtEvent, ArtEventBL> _mapperToBL;
        IArtEventFilter<ArtEvent> _filter;
        IArtEventSort<ArtEvent> _sorter;
        public ArtEventBLService(
            IRepositoryAsync<ArtEvent> artEventRepository, 
            IMapper<ArtEvent, ArtEventBL> mapperToBL,
            IArtEventFilter<ArtEvent> artEventFilter,
            IArtEventSort<ArtEvent> artEventSorter
            )
        {
            _repository = artEventRepository;
            _mapperToBL = mapperToBL;
            _filter = artEventFilter;
            _sorter = artEventSorter;
        }

        public Task CreateAsync(ArtEventBL artEvevnt)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<PagedList<ArtEventBL>> GetAllAsync( PagesState pagesStatus)
            {
            PagesState _pagesStatus;
            _pagesStatus = pagesStatus ?? new PagesState();

            var artEventsQuery = _repository.GetAll();
            artEventsQuery = _filter.FilterBy(artEventsQuery, pagesStatus);
            artEventsQuery = _sorter.SortBy(artEventsQuery, pagesStatus);

            var pagedArtEvents = await PagedList<ArtEvent>.TakePagedListAsync(artEventsQuery, pagesStatus.PageNumber, pagesStatus.PageSize);
            
            return pagedArtEvents.MapTo(_mapperToBL);
            }

        public async Task<ArtEventBL> GetAsync(int id)
        {
            return _mapperToBL.Map(await _repository.GetAsync(id));
        }

        public Task UpdateAsync(ArtEventBL artEvevnt)
        {
            throw new NotImplementedException();
        }
        public async Task<List<ArtEventBL>> GetListOfArtEvent(IEnumerable<int> incomingIDs)
        {

            var artEventList = await _repository.GetAll().Where(artEvent => incomingIDs.Contains(artEvent.Id)).ToListAsync();

            List<ArtEventBL> artEventListBL = new(); 
            foreach (var item in artEventList)
            {
                artEventListBL.Add(_mapperToBL.Map(item));
            }

            return artEventListBL;
        }
    }
}
