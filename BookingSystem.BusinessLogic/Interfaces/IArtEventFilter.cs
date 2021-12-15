using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.BusinessLogic.BusinesLogicModels;

namespace BookingSystem.BusinessLogic.Interfaces
{
    public interface IArtEventFilter<T> 
    {
        public IQueryable<T> FilterBy(IQueryable<T> source, PagesState pagesState);
    }
}
