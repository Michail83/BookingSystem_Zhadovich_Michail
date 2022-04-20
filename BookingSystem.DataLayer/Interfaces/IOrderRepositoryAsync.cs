using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.DataLayer.EntityModels;

namespace BookingSystem.DataLayer.Interfaces
{
    public interface IOrderRepositoryAsync
    {
        public IQueryable<Order> GetAll(string email);
        public Task<Order> GetAsync(int ID, string email);
        public Task UpdateAsync(Order order);
        public Task CreateAsync(Order order);
        public Task DeleteAsync(int ID);
    }
}
