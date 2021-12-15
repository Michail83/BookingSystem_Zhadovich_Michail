using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.BusinessLogic.BusinesLogicModels
{
    public class PagesState
    {
        private const byte _maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize {
            get 
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value < _maxPageSize && value > 0) ? value : _pageSize;
            }
        }
        public string  SortBy { get; set; }
        public string NameForFilter { get; set; }
        public string TypeForFilter { get; set; }
    }
}
