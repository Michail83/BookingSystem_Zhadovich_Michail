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
    public class ClassicMusicBLService : IBusinessLayerCRUDServiceAsync<ClassicMusicBL>
    {
        IRepositoryAsync<ClassicMusic> _repository;
        IMapper<ClassicMusic, ClassicMusicBL> _mapperToOpenAirBLEvents;
        IMapper<ClassicMusicBL, ClassicMusic> _mapperFromOpenAirBLEvents;

        public ClassicMusicBLService
            (
            IRepositoryAsync<ClassicMusic> repository, 
            IMapper<ClassicMusic, ClassicMusicBL> mapperToOpenAirBLEvents, 
            IMapper<ClassicMusicBL, ClassicMusic> mapperFromOpenAirBLEvents)
        {
            _repository = repository;
            _mapperToOpenAirBLEvents= mapperToOpenAirBLEvents;
            _mapperFromOpenAirBLEvents = mapperFromOpenAirBLEvents;
        }
        public async Task CreateAsync(ClassicMusicBL openAirArtEvevnt)
        {
            await _repository.CreateAsync(_mapperFromOpenAirBLEvents.Map(openAirArtEvevnt));
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<PagedList<ClassicMusicBL>> GetAllAsync(PagesState pagesStatus)
        {
            PagesState _pagesStatus;
            _pagesStatus = pagesStatus ?? new PagesState();

            var pagedResult = await PagedList<ClassicMusic>.TakePagedListAsync(_repository.GetAll(), pagesStatus.PageNumber, pagesStatus.PageSize);
            return pagedResult.MapTo(_mapperToOpenAirBLEvents);
        }

        public async Task<ClassicMusicBL> GetAsync(int id)
        {
            return _mapperToOpenAirBLEvents.Map(await _repository.GetAsync(id));
        }

        public async Task UpdateAsync(ClassicMusicBL openAirArtEvevnt)
        {
            await _repository.UpdateAsync(_mapperFromOpenAirBLEvents.Map(openAirArtEvevnt));
        }
    }
}
