using System.ComponentModel.DataAnnotations;

namespace TatilSitesi.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public bool CityStatu { get; set; }
        public List<Hotel> Hotels { get; set; }

    }
}
