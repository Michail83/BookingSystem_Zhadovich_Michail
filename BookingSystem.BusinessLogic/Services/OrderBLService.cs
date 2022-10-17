using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.DataLayer.EntityModels;
using BookingSystem.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.BusinessLogic.Services
{
    public class OrderBLService
    {
        IRepositoryAsync<ArtEvent> _artEventRepository;
        IOrderRepositoryAsync _orderRepository;
        IMapper<Order, OrderBL> _mapperOrderToOrderBL;
        IMapper<OrderBL, Order> _mapperOrderBL_toOrder;
        IEmailService _mailService;


        public OrderBLService
            (
            IOrderRepositoryAsync repository,
            IRepositoryAsync<ArtEvent> artEventRepository,
            IMapper<Order, OrderBL> mapperOrderToOrderBL,
            IMapper<OrderBL, Order> mapperOrderBL_toOrder,
            IEmailService mailService
            )
        {
            _orderRepository = repository;
            _artEventRepository = artEventRepository;
            _mapperOrderToOrderBL = mapperOrderToOrderBL;
            _mapperOrderBL_toOrder = mapperOrderBL_toOrder;
            _mailService = mailService;
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderBL>> GetAllAsync(string email)
        {
            var orderList = await _orderRepository.GetAll(email).ToListAsync();
            List<OrderBL> orderBLs = new();

            foreach (var order in orderList)
            {
                OrderBL orderBL;
                if (order.IsPaid)
                {
                    orderBL = JsonConvert.DeserializeObject<OrderBL>(order.PaidOrder);
                }
                else
                {
                    orderBL = _mapperOrderToOrderBL.Map(order);
                }                
                orderBLs.Add(orderBL);
            }
            return orderBLs;
        }
        public async Task<int> GetOrdersCount(string email)
        {
            var orderCount = await _orderRepository.GetAll(email).CountAsync();

            return orderCount;
        }
                
        public async Task<OrderBL> GetAsync(int id, string currentUserEmail)
        {
            var order = await _orderRepository.GetAll(currentUserEmail).FirstOrDefaultAsync(order=>order.Id==id);
            if (order==null)
            {
                return null;
            }                       
            return _mapperOrderToOrderBL.Map(order);
        }

       

        public async Task CreateAsync(OrderBL orderBL)
        {
            try
            {
                var order = _mapperOrderToOrderBL.Map(await _orderRepository.CreateAsync(_mapperOrderBL_toOrder.Map(orderBL)));
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"<h2> User {orderBL.UserEmail} created order<h2>");
                sb.Append(@"<table>");

                sb.Append(@"<thead>
                                <th> Title </th>
                                <th> Ordered count </th>
                                <th> Date  </th>
                                <th> Time  </th>

                                <th>Place</th>
                            </thead>");
                foreach (var orderedItem in order.ListOfReservedEventTickets)
                {
                    sb.Append(@"<tr>");

                    sb.Append($"<td>{orderedItem.ArtEventBL.EventName}</td>");
                    sb.Append($"<td>{orderedItem.Quantity}</td>");
                    sb.Append($"<td>{orderedItem.ArtEventBL.Date.ToShortDateString()}</td>");
                    sb.Append($"<td>{orderedItem.ArtEventBL.Date.ToShortTimeString()}</td>");

                    sb.Append($"<td>{orderedItem.ArtEventBL.Place}</td>");
                    sb.Append(@"</tr>");
                }
                sb.Append(@"<table>");
                sb.Append(@"<h6>Thank you for you order</h6.");


                MailRequest mailRequest = new MailRequest
                {
                    ToEmail = orderBL.UserEmail,

                    Body = sb.ToString(),

                    Subject = "Order was created by     bookingsystem-zhadovichmichail.herokuapp.com"
                };

                await _mailService.SendEmailAsync(mailRequest, true);
            }
            catch (Exception ex)
            {
                return;
            }

        }

        public async Task<bool> UpdateAsync(OrderBL order)
        {
            try
            {
                await _orderRepository.UpdateAsync(_mapperOrderBL_toOrder.Map(order));
            }
            catch (Exception)
            {

                return false;
            }
            

            return true;
        }
    }
}
