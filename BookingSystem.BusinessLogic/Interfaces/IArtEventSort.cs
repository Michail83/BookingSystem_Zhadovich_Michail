using BookingSystem.BusinessLogic.BusinesLogicModels;
using System.Linq;

namespace BookingSystem.BusinessLogic.Interfaces
{
    public interface IArtEventSort<T>
    {
        public IQueryable<T> SortBy(IQueryable<T> source, PagesState pagesState);
    }
}
