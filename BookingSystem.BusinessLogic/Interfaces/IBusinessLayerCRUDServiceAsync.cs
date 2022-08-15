using BookingSystem.BusinessLogic.BusinesLogicModels;
using System.Threading.Tasks;

namespace BookingSystem.BusinessLogic.Interfaces
{
    public interface IBusinessLayerCRUDServiceAsync<T> where T : class
    {
        public Task<PagedList<T>> GetAllAsync(PagesState pagesStatus);
        public Task<T> GetAsync(int id);
        public Task UpdateAsync(T artEvevnt);
        public Task CreateAsync(T artEvevnt);
        public Task DeleteAsync(int id);

    }
}
