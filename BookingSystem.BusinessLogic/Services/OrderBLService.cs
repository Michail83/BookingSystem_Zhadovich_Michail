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
using AutoMapper;

namespace BookingSystem.BusinessLogic.Services
{
    public class OrderBLService
    {
        
        readonly IRepositoryAsync<ArtEvent> _artEventRepository;
        readonly IOrderRepositoryAsync _orderRepository;
        readonly IMapper _mapper;
        
        readonly IEmailService _mailService;


        public OrderBLService
            (
            IOrderRepositoryAsync repository,
            IRepositoryAsync<ArtEvent> artEventRepository,
            IMapper mapper,            
            IEmailService mailService
            )
        {
            _orderRepository = repository;
            _artEventRepository = artEventRepository;
            _mapper = mapper;           
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
                    orderBL = _mapper.Map<OrderBL>(order);
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
            return _mapper.Map<OrderBL>(order);
        }

        public async Task CreateAsync(OrderBL orderBL)
        {
            try
            {
                var order = _mapper.Map<OrderBL>(await _orderRepository.CreateAsync(_mapper.Map<Order>(orderBL)));





                StringBuilder sb = new();

                sb.AppendLine($"<h2> User {orderBL.UserEmail} created order<h2>");
                sb.Append("<table style=\"border: 1px solid black;padding:1px \">");

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


                MailRequest mailRequest = new()
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

        public async Task<bool> UpdateAsync(OrderBL orderBL)
        {
            try
            {
                await _orderRepository.UpdateAsync(_mapper.Map<Order>(orderBL));
            }
            catch (Exception)
            {

                return false;
            }
            

            return true;
        }
    }
}
