using System.ComponentModel.DataAnnotations;

namespace TatilSitesi.Models
{
    public class HotelDetail
    {
        [Key]
        public int HotelDetailId { get; set; }
        public bool Animation { get; set; }
        public bool GameRoom { get; set; }
        public bool ChildPark { get; set; }
        public bool Disco { get; set; }
        public bool IndoorRestaurant { get; set; }
        public bool OutdoorRestaurant { get; set; }
        public bool LobyBar { get; set; }
        public bool Beach { get; set; }
        public bool CarPark { get; set; }
        public bool Minibar { get; set; }
        public bool Shower { get; set; }
        public bool TV { get; set; }
        public bool Internet { get; set; }
        public bool AirConditioning { get; set; }
        public bool Balcony { get; set; }
        public bool Massage { get; set; }
        public bool Sauna { get; set; }
        public bool Bath { get; set; }
        public bool IndoorPool { get; set; }
        public bool OutdoorPool { get; set; }
        public bool Sunbed { get; set; }
        public bool Volleyball { get; set; }
        public bool Basketball { get; set; }
        public bool Football { get; set; }
        public bool TableTennis { get; set; }
        public bool AquaPark { get; set; }
        public bool RoomService { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
