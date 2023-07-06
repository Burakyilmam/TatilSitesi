using System.ComponentModel.DataAnnotations;

namespace TatilSitesi.Models
{
    public class Destination
    {
        [Key]
        public int DestinationId { get; set; }
        public string DestinationName { get; set; }
        public string DestinationDescription { get; set; }
        public int DestinationCapacity { get; set; }
        public int DestinationDay { get;set; }
        public double DestinationPrice { get; set; }
        public double DestinationDiscount { get; set; }
        public bool DestinationStatu { get; set; }
        public string DestinationImageUrl { get; set; }
        public List<DestinationDetail> DestinationDetails { get; set; }
        public List<DestinationImage> DestinationImages { get; set; }
        public List<Comment> Comments { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
