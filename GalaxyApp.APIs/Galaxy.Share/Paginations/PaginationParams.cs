namespace GalaxyApp.Share.ResponseBase.Paginations
{
    public class PaginationParams
    {
        public PaginationParams(int pageSize = 0, int pageNumber = 0, ProductOrderEnum orderFilter = 0, string? searchFilter = null)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
            OrderFilter = orderFilter;
            SearchFilter = searchFilter;
        }

        public int PageSize { get; set; } = 0;
        public int PageNumber { get; set; } = 0;
        public ProductOrderEnum? OrderFilter { get; set; } = 0;
        public string? SearchFilter { get; set; }

    }
}
