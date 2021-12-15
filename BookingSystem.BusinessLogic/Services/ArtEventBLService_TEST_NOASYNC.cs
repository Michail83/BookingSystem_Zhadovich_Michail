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

namespace BookingSystem.BusinessLogic.Services
{
    public class ArtEventBLService_TEST_NOASYNC : IDataService_TEST<ArtEventBL>
    {
        IRepositoryAsync<ArtEvent> _repository;
        IMapper<ArtEvent, ArtEventBL> _mapperToBL;
        public ArtEventBLService_TEST_NOASYNC(IRepositoryAsync<ArtEvent> artEventRepository, IMapper<ArtEvent, ArtEventBL> mapperToBL)
        {
            _repository = artEventRepository;
            _mapperToBL = mapperToBL;
        }
        public IEnumerable<ArtEventBL> GetAll(PagesState pagesStatus)
            {
            PagesState _pagesStatus;
            _pagesStatus = pagesStatus ?? new PagesState();

            var result = new List<ArtEventBL>();

            foreach (var artEvent in  _repository
                .GetAll()
                .Skip((_pagesStatus.PageNumber - 1) * _pagesStatus.PageSize)
                .Take(_pagesStatus.PageSize)
                .ToList()
                )
            {
                result.Add(_mapperToBL.Map(artEvent));
            }           

            return result;
            }
    }
}
