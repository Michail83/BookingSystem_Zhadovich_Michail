using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.DataLayer.EntityModels;

namespace BookingSystem.BusinessLogic.Services
{
    public class FilterForArtEvent : IArtEventFilter<ArtEvent>
    {
        public IQueryable<ArtEvent> FilterBy(IQueryable<ArtEvent> source, PagesState pagesState)
        {
            var result = source;
            var filter = (pagesState?.TypeForFilter ?? String.Empty).ToLower();

            switch (filter)
            {
                case "classicmusic":
                    result= result.OfType<ClassicMusic>();
                    break;
                case "openair":
                    result = result.OfType<OpenAir>();
                    break;
                case "party":
                    result = result.OfType<Party>();
                    break;
                default:
                    break;
            }
            if (!String.IsNullOrEmpty(pagesState?.NameForFilter))
            {
                result = result.Where(artEvent => artEvent.EventName.Contains(pagesState.NameForFilter));
            }
            return result;
        }
    }
}