using BookingSystem.BusinessLogic.BusinesLogicModels;
using System.Linq;


namespace BookingSystem.BusinessLogic.Interfaces
{
    internal interface _NOT_NEEDED_IArtEventPagination<T> where T : ArtEventBL
    {
        IQueryable<T> Pagination(IQueryable<T> source, PagesState pagesState);
    }
}
