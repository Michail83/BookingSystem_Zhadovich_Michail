using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.DataLayer.EntityModels;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

namespace BookingSystem.BusinessLogic.Services
{
    public class SortForArtEvent<T> : IArtEventSort<T> where T : ArtEvent
    {
        public IQueryable<T> SortBy(IQueryable<T> source, string sortBy)
        {
            IQueryable<T> result;
            if (string.IsNullOrWhiteSpace(sortBy))
            {
                return result = source.OrderBy("Id");
            }

            var artEventParams = sortBy.Trim().Split(',');
            var propertiesInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var artEventsQueryBuilder = new StringBuilder();

            foreach (var param in artEventParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertiesInfo.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                var sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";

                artEventsQueryBuilder.Append($"{objectProperty.Name.ToString()} {sortingOrder}, ");
            }

            var orderQuery = artEventsQueryBuilder.ToString().TrimEnd(',', ' ');

            if (string.IsNullOrWhiteSpace(orderQuery))
            {
                orderQuery = "Id ascending";
            }

            result = source.OrderBy(orderQuery);

            return result;
        }
    }
}
