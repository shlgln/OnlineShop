using OnlineShop.Entities;

namespace OnlineShop.Services.StoreRooms.Contracs
{
    public class StoreRoomInventoryListDto
    {
        public string ProductCode { get; set; }
        public string ProductTitle { get; set; }
        public string CategoryTitle { get; set; }
        public int Stock { get; set; }
        public int MinimumStock { get; set; }
        public string  Status 
        {
            get
            {
                if (Stock == 0)
                    return "NoAvailable";
                else if (0 < Stock && Stock <= MinimumStock)
                    return "Resdy to order";
                return "Available";
            }
        }
    }
}
