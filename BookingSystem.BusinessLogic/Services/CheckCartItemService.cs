using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.DataLayer.EntityModels;
using BookingSystem.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;



namespace BookingSystem.BusinessLogic.Services
{
    public class CheckCartItemService
    {
        IRepositoryAsync<ArtEvent> _repository;
        IMapper _mapper;
        public CheckCartItemService(IRepositoryAsync<ArtEvent> artEventRepository, IMapper mapper)
        {
            _repository = artEventRepository;
            _mapper = mapper;
        }

        public async Task<CheckCartResult> CheckCartItem(CartItem cartItem)
        {
            var artEventFromCart = await _repository.GetAll().FirstOrDefaultAsync((artIvent) => artIvent.Id == cartItem.Id);
            CheckCartResult checkCartResult;
            if (artEventFromCart == null)
            {
                checkCartResult = new CheckCartResult { isExist = false, maxValue = 0 };
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
                artEventListBL.Add(_mapper.Map<ArtEventBL>(item));
            }
            return artEventListBL;
        }
    }
}