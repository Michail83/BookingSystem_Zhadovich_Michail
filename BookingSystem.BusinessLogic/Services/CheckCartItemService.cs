using AutoMapper;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.DataLayer.EntityModels;
using BookingSystem.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.BusinessLogic.Services
{
    public class CheckCartItemService
    {
        readonly IRepositoryAsync<ArtEvent> _repository;
        readonly IMapper _mapper;
        public CheckCartItemService(IRepositoryAsync<ArtEvent> artEventRepository, IMapper mapper)
        {
            _repository = artEventRepository;
            _mapper = mapper;
        }

        //public async Task<CheckCartResult> CheckCartItem(CartItem cartItem)
        //{
        //    var artEventFromCart = await _repository.GetAll().FirstOrDefaultAsync((artIvent) => artIvent.Id == cartItem.Id);
        //    CheckCartResult checkCartResult;
        //    if (artEventFromCart == null)
        //    {
        //        checkCartResult = new CheckCartResult { isExist = false, maxValue = 0 };
        //    }
        //    else
        //    {
        //        checkCartResult = new CheckCartResult { isExist = true, maxValue = (uint)artEventFromCart.AmountOfTickets };
        //    }
        //    return checkCartResult;
        //}
        public async Task<IEnumerable<ArtEventBL>> GetListOfArtEventsForReactCart(IEnumerable<int> incomingIDs)
        {
            var artEventList = await _repository.GetAll().Where(artEvent => incomingIDs.Contains(artEvent.Id)).ToListAsync();
            IEnumerable<ArtEventBL> artEventListBL = _mapper.Map<IEnumerable<ArtEventBL>>(artEventList);

            return artEventListBL;
        }
    }
}