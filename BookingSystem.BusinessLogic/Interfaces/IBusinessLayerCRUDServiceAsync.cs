using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.BusinessLogic.BusinesLogicModels;

namespace BookingSystem.BusinessLogic.Interfaces
{
    public interface IBusinessLayerCRUDServiceAsync<T> where T: class
    {
        public Task<PagedList<T>> GetAllAsync(PagesState pagesStatus);
        public Task<T> GetAsync(int id);
        public Task UpdateAsync(T artEvevnt);
        public Task CreateAsync(T artEvevnt);
        public Task DeleteAsync(int id);

    }
}
