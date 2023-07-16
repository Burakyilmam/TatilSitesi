using System.ComponentModel.DataAnnotations;

namespace TatilSitesi.Models
{
    public class Hotel
    {
        [Key] 
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string HotelAddress { get; set; }
        public string HotelDescription { get; set; }
        public string HotelThumbnailImageUrl { get; set; }
        public int HotelCount { get; set; }
        public int HotelStar { get; set; }
        public int HotelRating { get; set; }
        public bool HotelStatu { get; set; }
        public List<HotelRoom> HotelRooms { get; set; }
        public List<HotelDetail> HotelDetails { get; set; }
        public List<HotelImage> HotelImages { get; set; }
        public List<Comment> Comments { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
