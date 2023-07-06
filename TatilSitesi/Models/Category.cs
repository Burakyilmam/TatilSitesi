using System.ComponentModel.DataAnnotations;

namespace TatilSitesi.Models
{
    public class Category
    {
        [Key] 
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatu { get; set; }
        public List<Destination> Destination { get; set; }
    }
}
