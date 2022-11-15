namespace BookingSystem.BusinessLogic.BusinesLogicModels
{
    public class PagesState
    {
        private const byte _maxPageSize = 50;
        private int _pageNumber = 1;
        public int PageNumber {
            get 
            {
                return _pageNumber;
            }
            set
            {
                _pageNumber = (value > 0) ? value : 1;
            }
        }

        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value < _maxPageSize && value > 0) ? value : _pageSize;
            }
        }
        public string SortBy { get; set; } = "AmountOfTickets";
        public string NameForFilter { get; set; }
        public string TypeForFilter { get; set; }
    }
}
