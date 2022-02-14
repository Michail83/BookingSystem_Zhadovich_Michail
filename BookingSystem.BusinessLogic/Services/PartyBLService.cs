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
    public class PartyBLService : IBusinessLayerCRUDServiceAsync<PartyBL>
    {
        IRepositoryAsync<Party> _repository;
        IMapper<Party, PartyBL> _mapperToOpenAirBLEvents;
        IMapper<PartyBL, Party> _mapperFromOpenAirBLEvents;

        public PartyBLService
            (
            IRepositoryAsync<Party> repository, 
            IMapper<Party, PartyBL> mapperToOpenAirBLEvents, 
            IMapper<PartyBL, Party> mapperFromOpenAirBLEvents)
        {
            _repository = repository;
            _mapperToOpenAirBLEvents= mapperToOpenAirBLEvents;
            _mapperFromOpenAirBLEvents = mapperFromOpenAirBLEvents;
        }
        public async Task CreateAsync(PartyBL openAirArtEvevnt)
        {
            await _repository.CreateAsync(_mapperFromOpenAirBLEvents.Map(openAirArtEvevnt));
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<PagedList<PartyBL>> GetAllAsync(PagesState pagesStatus)
        {
            PagesState _pagesStatus;
            _pagesStatus = pagesStatus ?? new PagesState();

            var pagedResult = await PagedList<Party>.TakePagedListAsync(_repository.GetAll(), pagesStatus.PageNumber, pagesStatus.PageSize);
            return pagedResult.MapTo(_mapperToOpenAirBLEvents);
        }

        public async Task<PartyBL> GetAsync(int id)
        {
            return _mapperToOpenAirBLEvents.Map(await _repository.GetAsync(id));
        }

        public async Task UpdateAsync(PartyBL openAirArtEvevnt)
        {
            await _repository.UpdateAsync(_mapperFromOpenAirBLEvents.Map(openAirArtEvevnt));
        }
    }
}
