using BookingSystem.DataLayer.EntityModels;
using BookingSystem.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.Extensions.Logging;
//using System.Diagnostics;


namespace BookingSystem.DataLayer.EntityFramework.Repository
{
    public class OrderRepository : IOrderRepositoryAsync
    {
        DbContext _dbContext;
        DbSet<Order> _orders;
        DbSet<ArtEvent> _artEvents;



        public OrderRepository(BookingSystemDBContext dbContext)
        {
            _dbContext = dbContext;
            _orders = _dbContext.Set<Order>();
            _artEvents = _dbContext.Set<ArtEvent>();
        }

        //   неожиданное поведение  -   ИЗМЕНЯЕТ ДАННЫЕ в  ArtEvents
        public async Task CreateAsync(Order order)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    await _orders.AddAsync(order);

                    foreach (var orderAndArtEvent in order.OrderAndArtEvents)
                    {
                        var artEventToChange = _artEvents.First(artEvent => artEvent.Id == orderAndArtEvent.ArtEventId);
                        artEventToChange.AmountOfTickets = artEventToChange.AmountOfTickets - orderAndArtEvent.NumberOfBookedTicket;
                        if (artEventToChange.AmountOfTickets < 0)
                        {
                            throw new Exception();
                        }
                    }
                    await _dbContext.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();

                }
            }
        }

        public async Task DeleteAsync(int ID)
        {
            var orderToRemove = await _orders.FirstOrDefaultAsync(order => order.Id == ID);
            _orders.Remove(orderToRemove);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Order> GetAll(string email)
        {
            var queryResult = _orders.Where(order => String.Equals(order.UserEmail, email))
                .Include(c => c.OrderAndArtEvents)
                .ThenInclude(rel => rel.ArtEvent)
                .AsNoTracking();
            return queryResult;
        }

        public async Task<Order> GetAsync(int ID, string email)
        {
            var order = await _orders.FirstOrDefaultAsync(order => order.Id == ID && order.UserEmail == email);
            return order;
        }

        public async Task UpdateAsync(Order order)
        {
            _orders.Update(order);
            await _dbContext.SaveChangesAsync();
        }
    }
}
