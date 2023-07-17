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
        public IActionResult HotelDetailUpdate(HotelDetail m)
        {
            var hoteldetails = hr.Get(m.HotelDetailId);

            hoteldetails.Disco = m.Disco;
            hoteldetails.CarPark = m.CarPark;
            hoteldetails.TV = m.TV;   
            hoteldetails.Sauna = m.Sauna;
            hoteldetails.Shower = m.Shower;
            hoteldetails.Sunbed = m.Sunbed;
            hoteldetails.TableTennis = m.TableTennis;
            hoteldetails.Beach = m.Beach;
            hoteldetails.OutdoorRestaurant = m.OutdoorRestaurant;
            hoteldetails.IndoorRestaurant = m.IndoorRestaurant;
            hoteldetails.AirConditioning = m.AirConditioning;
            hoteldetails.Animation = m.Animation;
            hoteldetails.AquaPark = m.AquaPark;
            hoteldetails.Balcony = m.Balcony;
            hoteldetails.Basketball = m.Basketball;
            hoteldetails.Bath = m.Bath;
            hoteldetails.Beach = m.Beach;
            hoteldetails.ChildPark = m.ChildPark;
            hoteldetails.Football = m.Football;
            hoteldetails.GameRoom = m.GameRoom;
            hoteldetails.HotelDetailId = m.HotelDetailId;
            hoteldetails.HotelId = m.HotelId;
            hoteldetails.IndoorPool = m.IndoorPool;
            hoteldetails.OutdoorPool = m.OutdoorPool;
            hoteldetails.Minibar = m.Minibar;
            hoteldetails.Massage = m.Massage;
            hoteldetails.Internet = m.Internet;
            hoteldetails.LobyBar = m.LobyBar;
            hoteldetails.Volleyball = m.Volleyball;
            hoteldetails.TableTennis = m.TableTennis;

            hr.Update(hoteldetails);
            return RedirectToAction("HotelDetailList");
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
