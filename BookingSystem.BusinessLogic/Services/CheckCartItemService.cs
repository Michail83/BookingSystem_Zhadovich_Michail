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
    public class CheckCartItemService
    {
        IRepositoryAsync<ArtEvent> _repository;
        IMapper<ArtEvent, ArtEventBL> _mapperToBL;
        public CheckCartItemService(IRepositoryAsync<ArtEvent> artEventRepository, IMapper<ArtEvent,ArtEventBL> mapper)
        {
            _repository = artEventRepository;
            _mapperToBL = mapper;
        }

        public async Task<CheckCartResult> CheckCartItem(CartItem cartItem)
        {            
            var artEventFromCart = await _repository.GetAll().FirstOrDefaultAsync((artIvent)=> artIvent.Id == cartItem.Id);
            CheckCartResult checkCartResult;
            if (artEventFromCart == null)
            {
                checkCartResult = new CheckCartResult { isExist = false, maxValue=0 };
            }
            else
            {
                checkCartResult = new CheckCartResult { isExist = true, maxValue = (uint)artEventFromCart.AmountOfTickets };
            }            
            return checkCartResult;
        }
        public async Task<List<ArtEventBL>> GetListOfArtEventsForReactCart(IEnumerable<int> incomingIDs)
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