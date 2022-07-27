using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.DataLayer.EntityModels;

namespace BookingSystem.BusinessLogic.Services
{
    public class MapperOrderBLtoOrderDAL : IMapper<OrderBL, Order>
    {
        //IMapper<ArtEventBL, ArtEvent> _mapperArtEventBLToDAL;
        public MapperOrderBLtoOrderDAL(/*IMapper<ArtEventBL, ArtEvent> mapperArtEventBLToDAL*/)
        {
            //_mapperArtEventBLToDAL = mapperArtEventBLToDAL;
        }

        public Order Map(OrderBL incomingOrderBL)
        {
            List<OrderAndArtEvent> orderAndArtEvent = new();

            foreach (var cartWithQuantity in incomingOrderBL.ListOfReservedEventTickets)
            {
                orderAndArtEvent.Add(
                    new OrderAndArtEvent
                    {
                        ArtEventId = cartWithQuantity.ArtEventBL.Id,
                        NumberOfBookedTicket = cartWithQuantity.Quantity
                    });
            }
            Order result = new Order
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
