using BookingSystem.BusinessLogic.BusinesLogicModels;
using System.Collections.Generic;

namespace BookingSystem.BusinessLogic.Interfaces
{
    public interface IDataService_TEST<T> where T : class
    {
        public IEnumerable<T> GetAll(PagesState pagesStatus);
    }
}
