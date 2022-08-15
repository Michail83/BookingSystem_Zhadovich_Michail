using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.DataLayer.EntityModels;
using System.Collections.Generic;
using System.Linq;

namespace BookingSystem.BusinessLogic.Services
{
    public class MapperOrderBLtoOrderDAL : IMapper<OrderBL, Order>
    {
        public Order Map(OrderBL incomingOrderBL)
        {
            List<OrderAndArtEvent> orderAndArtEvent = new();
            orderAndArtEvent.AddRange(incomingOrderBL.ListOfReservedEventTickets.Select(cartWithQuantity => new OrderAndArtEvent
            {
                ArtEventId = cartWithQuantity.ArtEventBL.Id,
                NumberOfBookedTicket = cartWithQuantity.Quantity
            }));
            Order result = new()
            {
                Id = incomingOrderBL.Id,
                UserEmail = incomingOrderBL.UserEmail,
                TimeOfCreation = incomingOrderBL.TimeOfCreation,
                OrderAndArtEvents = orderAndArtEvent
            };
            return result;
        }
    }
}
