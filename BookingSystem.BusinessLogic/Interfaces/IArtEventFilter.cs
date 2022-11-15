using BookingSystem.BusinessLogic.BusinesLogicModels;
using System.Linq;

namespace BookingSystem.BusinessLogic.Interfaces
{
    public interface IArtEventFilter<T>
    {
        public IQueryable<T> FilterBy(IQueryable<T> source, PagesState pagesState);
    }
}
