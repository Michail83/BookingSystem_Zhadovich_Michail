using System.Linq;

namespace BookingSystem.BusinessLogic.Interfaces
{
    public interface IArtEventSort<T>
    {
        public IQueryable<T> SortBy(IQueryable<T> source, string sortBy);
    }
}
