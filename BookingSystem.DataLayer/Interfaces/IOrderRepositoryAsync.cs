using BookingSystem.DataLayer.EntityModels;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.DataLayer.Interfaces
{
    public interface IOrderRepositoryAsync
    {
        public IQueryable<Order> GetAll(string email);
        public Task<Order> GetAsync(int ID, string email);
        public Task<Order> UpdateAsync(Order order);
        public Task<Order> CreateAsync(Order order);
        public Task DeleteAsync(int ID);
    }
}
