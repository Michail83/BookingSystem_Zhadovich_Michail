using BookingSystem.DataLayer.EntityModels;
using BookingSystem.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Infrastructure.Models.Result;
//using Microsoft.Extensions.Logging;
//using System.Diagnostics;


namespace BookingSystem.DataLayer.EntityFramework.Repository
{
    public class OrderRepositoryInMemory : IOrderRepositoryAsync
    {
        readonly DbContext _dbContext;
        readonly DbSet<Order> _orders;
        readonly DbSet<ArtEvent> _artEvents;

        public OrderRepositoryInMemory(BookingSystemDBContext dbContext)
        {
            _dbContext = dbContext;
            _orders = _dbContext.Set<Order>();
            _artEvents = _dbContext.Set<ArtEvent>();
        }

        //   неожиданное поведение??  -   ИЗМЕНЯЕТ ДАННЫЕ в  ArtEvents
        public async Task<Result<Order>> CreateAsync(Order order)
        {
            try
            {
                await _orders.AddAsync(order);

                foreach (var orderAndArtEvent in order.OrderAndArtEvents)
                {
                    var artEventToChange = _artEvents.First(artEvent => artEvent.Id == orderAndArtEvent.ArtEventId);
                    artEventToChange.AmountOfTickets -= orderAndArtEvent.NumberOfBookedTicket;
                    if (artEventToChange.AmountOfTickets < 0)
                    {                        
                        throw new Exception();
                    }
                }
                await _dbContext.SaveChangesAsync();
                return new SuccessResult<Order>(order);
            }
            catch (Exception ex)
            {                    
                return new ErrorResult<Order>(Messages.NoErrorHandle);
            }
        }

        public async Task<Result> DeleteAsync(int ID)
        {
            try
            {
                var orderToRemove = await _orders.FirstOrDefaultAsync(order => order.Id == ID);
                _orders.Remove(orderToRemove);
                await _dbContext.SaveChangesAsync();
                return new SuccessResult();
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.NoErrorHandle);
            }            
        }

        public Result<IQueryable<Order>> GetAll(string email)
        {
            try
            {
                var queryResult = _orders.Where(order => String.Equals(order.UserEmail, email))
                .Include(c => c.OrderAndArtEvents)
                .ThenInclude(rel => rel.ArtEvent)
                .AsNoTracking();
                return new SuccessResult<IQueryable<Order>>(queryResult) ;
            }
            catch (Exception)
            {

                return new ErrorResult<IQueryable<Order>>(Messages.NoErrorHandle);
            }            
        }

        public async Task<Result<Order>> GetAsync(int ID, string email)
        {
            try
            {
                var order = await _orders
                    .Include(c => c.OrderAndArtEvents)
                    .ThenInclude(rel => rel.ArtEvent)
                    .AsNoTracking().FirstAsync(order => order.Id == ID && order.UserEmail == email);
                return new SuccessResult<Order> (order);
            }
            catch (Exception)
            {
                return new ErrorResult<Order>(Messages.NoErrorHandle);
            }
        }

        public async Task<Result<Order>> UpdateAsync(Order order)
        {
            try
            {
                var _order = await _orders.FirstOrDefaultAsync((ord) => ord.Id == order.Id);
                _order.IsPaid = order.IsPaid;
                _order.PaidOrder = order.PaidOrder;
                await _dbContext.SaveChangesAsync();
                return new SuccessResult<Order>(_order);
            }
            catch (Exception)
            {
                return new ErrorResult<Order>(Messages.NoErrorHandle);
            }           
        }
    }
}
