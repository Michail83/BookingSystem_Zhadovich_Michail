using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.BusinessLogic.BusinesLogicModels;

namespace BookingSystem.BusinessLogic.Interfaces
{
    public interface IDataService_TEST<T> where T: class
    {
        public IEnumerable<T> GetAll(PagesState pagesStatus);
    }
}
