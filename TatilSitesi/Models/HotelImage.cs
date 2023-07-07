using System.ComponentModel.DataAnnotations;

namespace TatilSitesi.Models
{
    public class HotelImage
    {
        [Key] 
        public int HotelImageId { get; set; }
        public string HotelImageUrl { get; set; }
        public bool HotelImageStatu { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
