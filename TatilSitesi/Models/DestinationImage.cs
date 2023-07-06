using System.ComponentModel.DataAnnotations;

namespace TatilSitesi.Models
{
    public class DestinationImage
    {
        [Key] 
        public int DestinationImageId { get; set; }
        public string DestinationImageUrl { get; set; }
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
    }
}
