using BookingSystem.BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;


namespace BookingSystem.BusinessLogic.BusinesLogicModels
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalItemsCount { get; private set; }

        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;

        private PagedList(List<T> items, int totalItemsCount, int pageNumber, int pageSize)
        {
            this.TotalItemsCount = totalItemsCount;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(totalItemsCount / (double)pageSize);

            this.AddRange(items);
        }
        public static async Task<PagedList<T>> TakePagedListAsync(IQueryable<T> source, PagesState pagesState)
        {
            var count = await source.CountAsync();
            var pageNumber = pagesState.PageNumber <= count ? pagesState.PageNumber : 1;
            var items = await source.Skip((pageNumber - 1) * pagesState.PageSize).Take(pagesState.PageSize).ToListAsync();

            return new PagedList<T>(items, count, pageNumber, pagesState.PageSize);
        }
        public PagedList<Y> MapTo<Y>(IMapper mapper)
        {
            List<Y> mappedsource = new ();         
            mappedsource.AddRange(mapper.Map<IEnumerable<Y>>(this));
            
            return new PagedList<Y>(mappedsource, TotalItemsCount, CurrentPage, PageSize);
        }
    }
}
