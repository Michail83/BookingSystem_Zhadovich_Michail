using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.WEB.Models;
using System.Collections.Generic;

namespace BookingSystem.WEB.Services
{
    public class MapperOrderBLtoViewModel /*: IMapper<ArtEventBL, ArtEventViewModel>*/
    {
        IMapper<ArtEventBL, ArtEventViewModel> _mapper;

        public MapperOrderBLtoViewModel(IMapper<ArtEventBL, ArtEventViewModel> mapper)
        {
            _mapper = mapper;
        }
        public OrderViewModel Map(OrderBL incoming)
        {
            List<CartWithQuantityViewModel> newListOfReservedEventTickets = new();
            foreach (var ReservedEventTicket in incoming.ListOfReservedEventTickets)
            {
                newListOfReservedEventTickets.Add(new CartWithQuantityViewModel
                { 
                    Quantity = ReservedEventTicket.Quantity,
                    ArtEventViewModel = _mapper.Map(ReservedEventTicket.ArtEventBL)                    
                });
            }
            var result = new OrderViewModel
            {
                Id = incoming.Id,
                TimeOfCreation = incoming.TimeOfCreation,
                UserEmail = incoming.UserEmail,
                ListOfReservedEventTickets = newListOfReservedEventTickets
            };
            return result;
        }
        public List<OrderViewModel> Map(IEnumerable<OrderBL> incoming) 
        {
            List<OrderViewModel> result = new ();
            foreach (var orderBL in incoming) 
            {
                result.Add(Map(orderBL));

            }
            return result;
        }
    }
}
