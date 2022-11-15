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
using BookingSystem.Infrastructure.Models.Result;
using System.Linq;

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

        public async Task<Result<IEnumerable<OrderBL>>> GetAllAsync(string email)
        {
            var result =  _orderRepository.GetAll(email);
            if (result.Success)
            {
                var orderList = await result.Data.ToListAsync();
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
                return new SuccessResult<IEnumerable<OrderBL>>(orderBLs);
            }
            else 
            {
                return new ErrorResult<IEnumerable<OrderBL>>(Messages.NoErrorHandle);
            }
            
        }
        public async Task<Result<int>> GetOrdersCount(string email)
        {

            var result =  _orderRepository.GetAll(email);
            if (result.Success)
            {
                try
                {
                    var resulrBL = await result.Data.CountAsync();
                    return new SuccessResult<int>(resulrBL);
                }
                catch (Exception)
                {

                    return new ErrorResult<int>(Messages.NoErrorHandle);
                }

            }
            else 
            {
                var repositoryError = (ErrorResult<IQueryable<Order>>)result;
                return new ErrorResult<int>(repositoryError.Message, repositoryError.Errors);
            }
        }
                
        public async Task<Result<OrderBL>> GetAsync(int id, string currentUserEmail)
        {
            try
            {
                var result = await _orderRepository.GetAsync(id, currentUserEmail);
                if (result.Success)
                {
                    return new SuccessResult<OrderBL>(_mapper.Map<OrderBL>(result.Data));
                }
                else 
                {
                    var repositoryError = (ErrorResult<Order>)result;

                    return new ErrorResult<OrderBL>(repositoryError.Message, repositoryError.Errors);
                }

            }
            catch (Exception)
            {

                return new ErrorResult<OrderBL>(Messages.NoErrorHandle);
            }            
           
        }

        public async Task<Result> CreateAsync(OrderBL orderBL)
        {
            try
            {
                var result = await _orderRepository.CreateAsync(_mapper.Map<Order>(orderBL));
                if (result.Success)
                {
                    var createdOrderBL = _mapper.Map<OrderBL>(result.Data);

                    StringBuilder sb = new();

                    sb.AppendLine($"<h2> User {createdOrderBL.UserEmail} created order<h2>");
                    sb.Append("<table style=\"border: 1px solid black;padding:1px \">");

                    sb.Append(@"<thead>
                                <th> Title </th>
                                <th> Ordered count </th>
                                <th> Date  </th>
                                <th> Time  </th>

                                <th>Place</th>
                            </thead>");
                    foreach (var orderedItem in createdOrderBL.ListOfReservedEventTickets)
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
                        ToEmail = createdOrderBL.UserEmail,

                        Body = sb.ToString(),

                        Subject = "Order was created by     bookingsystem-zhadovichmichail.herokuapp.com"
                    };

                    await _mailService.SendEmailAsync(mailRequest, true);

                    return new SuccessResult();

                }
                else return new ErrorResult(Messages.NoErrorHandle);
                





                
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.NoErrorHandle);
            }
        }

        public async Task<Result> UpdateAsync(OrderBL orderBL)
        {
            try
            {
                var result =   await _orderRepository.UpdateAsync(_mapper.Map<Order>(orderBL));
                if (result.Success)
                {
                    return new SuccessResult();
                }
                else 
                {
                    return new ErrorResult(Messages.NoErrorHandle);
                }
            
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.NoErrorHandle);
            }            
        }
    }
}
