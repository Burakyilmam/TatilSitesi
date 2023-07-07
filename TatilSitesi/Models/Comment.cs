using System.ComponentModel.DataAnnotations;

namespace TatilSitesi.Models
{
    public class Comment
    {
        [Key] 
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public bool CommentStatu { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
