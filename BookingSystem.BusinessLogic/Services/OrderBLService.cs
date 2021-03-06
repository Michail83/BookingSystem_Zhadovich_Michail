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
             List<OrderBL> orderBLs = new ();

            foreach (var order in orderList)
            {
                orderBLs.Add(_mapperOrderToOrderBL.Map(order));
            }
            return orderBLs;
        }

        public Task<OrderBL> GetAsync(int id, string currentUserEmail)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(OrderBL artEvevnt)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(OrderBL orderBL)
        {
            try
            {                
                await _orderRepository.CreateAsync(_mapperOrderBL_toOrder.Map(orderBL));
                MailRequest mailRequest = new MailRequest 
                {
                    ToEmail = orderBL.UserEmail,
                    Body = "Test mail bode", 
                    Subject = "subject Test" 
                };

                await _mailService.SendEmailAsync(mailRequest);
            }
            catch (Exception)
            {
                return;
            }
            
        }

        private async Task<bool> UpdateOrderAsync(OrderBL order)
        {

           await _orderRepository.UpdateAsync(_mapperOrderBL_toOrder.Map(order));
            return true;
        }
    }
}
