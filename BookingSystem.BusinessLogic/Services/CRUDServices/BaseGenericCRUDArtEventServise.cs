using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookingSystem.DataLayer.EntityModels;
using BookingSystem.DataLayer.Interfaces;
using System.Threading.Tasks;
using AutoMapper;

namespace BookingSystem.BusinessLogic.Services.CRUDServices
{
    public abstract class BaseGenericCRUDArtEventService<TYPE_BL, TYPE_DAL> : IBusinessLayerCRUDServiceAsync<TYPE_BL> where TYPE_BL : ArtEventBL where TYPE_DAL: ArtEvent
    {
        internal readonly IRepositoryAsync<TYPE_DAL> _repository;
        internal readonly IMapper  _mapper;        
        public BaseGenericCRUDArtEventService(
            IRepositoryAsync<TYPE_DAL> repository, 
            IMapper autoMapper
            ) 
        {
            _repository = repository;
            _mapper = autoMapper;            
        }


        public virtual async Task CreateAsync(TYPE_BL artEventBL)
        {
            await _repository.CreateAsync(_mapper.Map<TYPE_DAL>(artEventBL));
        }

        public virtual async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public virtual async Task<PagedList<TYPE_BL>> GetAllAsync(PagesState pagesStatus)
        {
            PagesState _pagesStatus;
            _pagesStatus = pagesStatus ?? new PagesState();

            var pagedResult = await PagedList<TYPE_DAL>.TakePagedListAsync(_repository.GetAll(), pagesStatus.PageNumber, pagesStatus.PageSize);
            return pagedResult.MapTo<TYPE_BL>(_mapper);
        }

        public virtual async Task<TYPE_BL> GetAsync(int id)
        {
            return _mapper.Map<TYPE_BL>(await _repository.GetAsync(id));
        }

        public virtual async Task UpdateAsync(TYPE_BL artEventBL)
        {
            await _repository.UpdateAsync(_mapper.Map<TYPE_DAL>(artEventBL));
        }
    }
}
