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
    internal class FilterForOpenAir : IArtEventFilter<OpenAir>
    {
        public IQueryable<OpenAir> FilterBy(IQueryable<OpenAir> source, PagesState pagesState)
        {
            var result = source;

            //switch ((pagesState.TypeForFilter ?? String.Empty).ToLower())
            //{
            //    case "classicMusic":
            //        result= result.OfType<ClassicMusic>();
            //        break;
            //    case "openAir":
            //        result = result.OfType<OpenAir>();
            //        break;
            //    case "party":
            //        result = result.OfType<Party>();
            //        break;
            //    default:
            //        break;
            //}
            if (!String.IsNullOrEmpty(pagesState.NameForFilter))
            {
                result = result.Where(artEvent => artEvent.IventName.Contains(pagesState.NameForFilter));
            }
            return result;
        }
    }
}
