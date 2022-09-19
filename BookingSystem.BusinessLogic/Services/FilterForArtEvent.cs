using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.DataLayer.EntityModels;
using System;
using System.Linq;

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
                    result = result.OfType<ClassicMusic>();
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
                result = result.Where(artEvent => artEvent.EventName.Contains(pagesState.NameForFilter.Trim(), StringComparison.InvariantCultureIgnoreCase));
            }
            return result;
        }
    }
}