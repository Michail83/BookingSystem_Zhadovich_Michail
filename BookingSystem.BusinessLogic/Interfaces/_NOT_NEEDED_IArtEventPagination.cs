using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.BusinessLogic.BusinesLogicModels;


namespace BookingSystem.BusinessLogic.Interfaces
{
    internal interface _NOT_NEEDED_IArtEventPagination<T> where T : ArtEventBL
    {
        IQueryable<T> Pagination(IQueryable<T> source, PagesState pagesState);
    }
}
