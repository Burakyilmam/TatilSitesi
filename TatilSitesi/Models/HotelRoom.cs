using System.ComponentModel.DataAnnotations;

namespace TatilSitesi.Models
{
    public class HotelRoom
    {
        [Key] 
        public int HotelRoomId { get; set; }
        public string HotelRoomName { get; set; }
        public double HotelRoomPrice { get; set; }
        public int HotelRoomPersonNumber { get; set; }
        public bool HotelRoomStatu { get; set; }
        public List<HotelRoomImage> hotelRoomImages { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
