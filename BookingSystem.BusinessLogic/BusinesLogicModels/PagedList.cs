using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookingSystem.BusinessLogic.Interfaces;


namespace BookingSystem.BusinessLogic.BusinesLogicModels
{
    public class PagedList<T> :List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalItemsCount { get; private set; }

        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;

        public PagedList(List<T> items, int totalItemsCount, int pageNumber, int pageSize)
        {
            this.TotalItemsCount = totalItemsCount;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(totalItemsCount / (double)pageSize);

            this.AddRange(items);
        }
        public static async Task<PagedList<T>> TakePagedListAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            pageNumber = pageNumber > 0 && pageNumber <= count ? pageNumber : 1;
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
        public PagedList<Y> MapTo<Y>(IMapper<T,Y> mapper)
        {
            var mappedsource = new List<Y>();
            foreach (var item in this)
            {
                mappedsource.Add(mapper.Map(item));
            }
            return new PagedList<Y>(mappedsource,TotalItemsCount, CurrentPage, PageSize);
        }

    }
}
