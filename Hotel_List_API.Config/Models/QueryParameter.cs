namespace Hotel_List_API.Configuration.Models
{
    public class QueryParameter
    {
        private int _pageSize = 10;
        public int StartIndex { get; set; }
        public int PageNumber { get; set; } 
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value;
            }
        }
    }
}
