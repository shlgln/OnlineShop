using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Services.StoreRooms.Contracs
{
    public class RegisterStoreroomDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Stock { get; set; }
    }
}
