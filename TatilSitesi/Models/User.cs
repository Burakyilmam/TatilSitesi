using System.ComponentModel.DataAnnotations;

namespace TatilSitesi.Models
{
    public class User
    {
        [Key] 
        public int UserId { get; set; }
        public string UserRealName { get; set; }
        public string UserSurname { get; set; }
        public string UserGender { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public string UserPhoneNumber { get; set; }
        public bool UserStatu { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
