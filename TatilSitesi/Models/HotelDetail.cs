using System.ComponentModel.DataAnnotations;

namespace TatilSitesi.Models
{
    public class HotelDetail
    {
        [Key]
        public int HotelDetailId { get; set; }
        public string Animation { get; set; }
        public string GameRoom { get; set; }
        public string Disco { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
