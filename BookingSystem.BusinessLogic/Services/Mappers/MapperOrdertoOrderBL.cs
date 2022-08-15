using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.DataLayer.EntityModels;
using System.Collections.Generic;

namespace BookingSystem.BusinessLogic.Services
{
    public class MapperOrdertoOrderBL : IMapper<Order, OrderBL>
    {
        IMapper<ArtEvent, ArtEventBL> _mapperArtEventToBL;
        public MapperOrdertoOrderBL(IMapper<ArtEvent, ArtEventBL> mapperArtEventToBL)
        {
            _mapperArtEventToBL = mapperArtEventToBL;
        }

        public OrderBL Map(Order incomingOrder)
        {
            List<CartWithQuantityBL> cartWithQuantity = new();
            foreach (var item in incomingOrder.OrderAndArtEvents)
            {
                CartWithQuantityBL newCartItem = new CartWithQuantityBL
                {
                    Quantity = item.NumberOfBookedTicket,
                    ArtEventBL = _mapperArtEventToBL.Map(item.ArtEvent)
                };
                cartWithQuantity.Add(newCartItem);
            }
            OrderBL result = new OrderBL
            {
                Id = incomingOrder.Id,
                UserEmail = incomingOrder.UserEmail,
                TimeOfCreation = incomingOrder.TimeOfCreation,
                ListOfReservedEventTickets = cartWithQuantity
            };
            return result;
        }
    }
}
