using Microsoft.EntityFrameworkCore;
using TatilSitesi.Models;

namespace TatilSitesi.Repository
{
    public class HotelRepository : GenericRepository<Hotel>
    {
        Context c = new Context();
        public List<Hotel> LowPriceHotelList(string u, string b)
        {
            return c.Set<Hotel>().Include(u).Include(b).OrderBy(hotel => hotel.HotelRooms.Min(room => room.HotelRoomPrice)).ToList();
        }
        public List<Hotel> HighPriceHotelList(string u, string b)
        {
            return c.Set<Hotel>().Include(u).Include(b).OrderByDescending(hotel => hotel.HotelRooms.Min(room => room.HotelRoomPrice)).ToList();
        }
        public List<Hotel> MostComment(string u, string b)
        {
            return c.Set<Hotel>().Include(u).Include(b).OrderByDescending(x => x.Comments.Count).ToList();
        }
    }
}
