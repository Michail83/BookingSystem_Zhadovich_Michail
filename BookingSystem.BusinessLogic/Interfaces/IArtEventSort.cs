using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.DataLayer.EntityModels;

namespace BookingSystem.BusinessLogic.Interfaces
{
    public interface IArtEventSort<T> 
    {
        public IQueryable<T> SortBy(IQueryable<T> source, string sortBy);
    }
}
