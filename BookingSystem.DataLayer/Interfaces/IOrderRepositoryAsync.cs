using BookingSystem.DataLayer.EntityModels;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Infrastructure.Models.Result;

namespace BookingSystem.DataLayer.Interfaces
{
    public interface IOrderRepositoryAsync
    {
        public Result<IQueryable<Order>> GetAll(string email);
        public Task<Result<Order>> GetAsync(int ID, string email);
        public Task<Result<Order>> UpdateAsync(Order order);
        public Task<Result<Order>> CreateAsync(Order order);
        public Task<Result> DeleteAsync(int ID);
    }
}
