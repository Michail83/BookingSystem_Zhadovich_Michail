using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.DataLayer.EntityModels;
using System.Linq.Dynamic.Core;
using System.Reflection;

namespace BookingSystem.BusinessLogic.Services
{
    public class SortForArtEvent<T> : IArtEventSort<T>
    {
        public IQueryable<T> SortBy(IQueryable<T> source, PagesState pagesState)
        {
			IQueryable<T> result;
			if (string.IsNullOrWhiteSpace(pagesState.SortBy))
			{
				return result = source;     //.OrderBy(x => x.IventName)		
			}

			var artEventParams = pagesState.SortBy.Trim().Split(',');
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

			//if (string.IsNullOrWhiteSpace(orderQuery))
			//{				
			//	return result = source.OrderBy(x => x.IventName);
			//}

			result = source.OrderBy(orderQuery);

			return result;			
        }
    }
}
