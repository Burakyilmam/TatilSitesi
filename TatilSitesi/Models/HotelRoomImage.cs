using System.ComponentModel.DataAnnotations;

namespace TatilSitesi.Models
{
    public class HotelRoomImage
    {
        [Key]
        public int HotelRoomImageId { get; set; }
        public string HotelRoomImageUrl { get; set;}
        public bool HotelRoomImageStatu { get; set;}
        public int HotelRoomId { get; set;}
        public HotelRoom HotelRoom { get; set;}
    }
}
