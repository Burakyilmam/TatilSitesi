using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using TatilSitesi.Models;
using TatilSitesi.Repository;
using X.PagedList;

namespace TatilSitesi.Controllers
{
    public class HotelDetailController : Controller
    {
        HotelDetailRepository hr = new HotelDetailRepository();
        public IActionResult HotelDetailList(string p ,int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View("~/Views/HotelDetail/HotelDetailList.cshtml", hr.List("Hotel").Where(x => (x.Hotel.HotelName.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower()))))).ToPagedList(page, 12));
            }
            return View(hr.List("Hotel").ToPagedList(page, 10));
        }
        [HttpGet]
        public IActionResult HotelDetailAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult HotelDetailAdd(HotelDetail m)
        {
            hr.Add(m);
            return RedirectToAction("HotelDetailList");
        }
        public IActionResult HotelDetailDelete(int id)
        {
            hr.Delete(new HotelDetail { HotelDetailId = id });
            return RedirectToAction("HotelDetailList");
        }
        public IActionResult HotelDetailUpdate(HotelDetail h)
        { 
            var hoteldetail = hr.Get(h.HotelDetailId);
            hoteldetail.HotelDetailId = h.HotelDetailId;
            hoteldetail.Animation = h.Animation;
            hoteldetail.GameRoom = h.GameRoom;
            hoteldetail.Disco = h.Disco;
            hoteldetail.HotelId = h.HotelId;
            hoteldetail.AirConditioning = h.AirConditioning;
            hoteldetail.AquaPark = h.AquaPark;
            hoteldetail.Balcony = h.Balcony;
            hoteldetail.Bath = h.Bath;
            hoteldetail.Beach = h.Beach;
            hoteldetail.IndoorPool = h.IndoorPool;
            hoteldetail.IndoorRestaurant = h.IndoorRestaurant;
            hoteldetail.Internet = h.Internet;
            hoteldetail.Massage = h.Massage;
            hoteldetail.Minibar = h.Minibar;
            hoteldetail.OutdoorPool = h.OutdoorPool;
            hoteldetail.OutdoorRestaurant = h.OutdoorRestaurant;
            hoteldetail.RoomService = h.RoomService;
            hoteldetail.Sauna = h.Sauna;
            hoteldetail.Shower = h.Shower;
            hoteldetail.Sunbed = h.Sunbed;
            hoteldetail.TV = h.TV;
            hoteldetail.TableTennis = h.TableTennis;
            hoteldetail.Volleyball = h.Volleyball;
            hoteldetail.LobyBar = h.LobyBar;
            hoteldetail.Basketball = h.Basketball;
            hoteldetail.CarPark = h.CarPark;
            hoteldetail.ChildPark = h.ChildPark;
            hoteldetail.Football = h.Football;
            hr.Update(hoteldetail);
            return RedirectToAction("HotelDetailList");
            }
        public IActionResult GetDetail(int id)
        {
            var hoteldetail = hr.Get(id);
            HotelDetail m = new HotelDetail()
            {
                HotelDetailId = hoteldetail.HotelDetailId,
                HotelId = hoteldetail.HotelId,
                Disco = hoteldetail.Disco,
                Animation = hoteldetail.Animation,
                AirConditioning = hoteldetail.AirConditioning,
                AquaPark = hoteldetail.AquaPark,
                Balcony = hoteldetail.Balcony,
                Basketball = hoteldetail.Basketball,
                Bath = hoteldetail.Bath,
                Beach = hoteldetail.Beach,
                CarPark = hoteldetail.CarPark,
                ChildPark = hoteldetail.ChildPark,
                Football = hoteldetail.Football,
                GameRoom = hoteldetail.GameRoom,
                IndoorPool = hoteldetail.IndoorPool,
                IndoorRestaurant = hoteldetail.IndoorRestaurant,
                OutdoorPool = hoteldetail.OutdoorPool,
                OutdoorRestaurant = hoteldetail.OutdoorRestaurant,
                Internet = hoteldetail.Internet,
                LobyBar = hoteldetail.LobyBar,
                Minibar = hoteldetail.Minibar,
                Massage = hoteldetail.Massage,
                RoomService = hoteldetail.RoomService,
                Sauna = hoteldetail.Sauna,
                Shower = hoteldetail.Shower,
                Sunbed = hoteldetail.Sunbed,
                TableTennis = hoteldetail.TableTennis,
                TV = hoteldetail.TV,
                Volleyball = hoteldetail.Volleyball
            };
            HotelRepository hot = new HotelRepository();

            var hotels = hot.List();

            var hotelItems = hotels.Select(c => new SelectListItem
            {
                Value = c.HotelId.ToString(),
                Text = c.HotelName
            }).ToList();

            ViewBag.Hotels = hotelItems;

            return View(m);
        }

        public IActionResult GetUpdate(int id)
        {
            var hoteldetail = hr.Get(id);
            HotelDetail m = new HotelDetail()
            {
                HotelDetailId = hoteldetail.HotelDetailId,
                HotelId = hoteldetail.HotelId,
                Disco = hoteldetail.Disco,
                Animation = hoteldetail.Animation,
                AirConditioning = hoteldetail.AirConditioning,
                AquaPark = hoteldetail.AquaPark,
                Balcony = hoteldetail.Balcony,
                Basketball = hoteldetail.Basketball,
                Bath = hoteldetail.Bath,
                Beach = hoteldetail.Beach,
                CarPark = hoteldetail.CarPark,
                ChildPark = hoteldetail.ChildPark,
                Football = hoteldetail.Football,
                GameRoom = hoteldetail.GameRoom,
                IndoorPool = hoteldetail.IndoorPool,
                IndoorRestaurant = hoteldetail.IndoorRestaurant,
                OutdoorPool = hoteldetail.OutdoorPool,
                OutdoorRestaurant = hoteldetail.OutdoorRestaurant,
                Internet = hoteldetail.Internet,
                LobyBar = hoteldetail.LobyBar,
                Minibar = hoteldetail.Minibar,
                Massage = hoteldetail.Massage,
                RoomService = hoteldetail.RoomService,
                Sauna = hoteldetail.Sauna,
                Shower = hoteldetail.Shower,
                Sunbed = hoteldetail.Sunbed,
                TableTennis = hoteldetail.TableTennis,
                TV = hoteldetail.TV,
                Volleyball = hoteldetail.Volleyball
            };
            HotelRepository hot = new HotelRepository();

            var hotels = hot.List();

            var hotelItems = hotels.Select(c => new SelectListItem
            {
                Value = c.HotelId.ToString(),
                Text = c.HotelName
            }).ToList();

            ViewBag.Hotels = hotelItems;

            return View(m);
        }
    }
}
