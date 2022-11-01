using BookingSystem.BusinessLogic.BusinesLogicModels;
using System.Threading.Tasks;

namespace BookingSystem.BusinessLogic.Interfaces
{
    public interface IBusinessLayerCRUDServiceAsync<T> where T : class
    {
        public Task<PagedList<T>> GetAllAsync(PagesState pagesStatus);
        public Task<T> GetAsync(int id);
        public Task UpdateAsync(T artEvent);
        public Task CreateAsync(T artEvent);
        public Task DeleteAsync(int id);

    }
}
