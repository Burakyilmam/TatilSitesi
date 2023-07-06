using System.ComponentModel.DataAnnotations;

namespace TatilSitesi.Models
{
    public class DestinationDetail
    {
        [Key]
        public int DestinationDetailId { get; set; }
        public string Animation { get; set; }
        public string GameRoom { get; set; }
        public string Disco { get; set; }
    }
}
