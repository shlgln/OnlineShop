namespace OnlineShop.Services.Queris.StoreRoomQueryis
{
    public class StoreRoomQueryFilter
    {
        public string? ProductCode { get; set; }
        public string? ProductTitle { get; set; }
        public string? CategoryTitle { get; set; }
        public int? Stock { get; set; }
        public int? MinimumStock { get; set; }
        public string? Status { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
