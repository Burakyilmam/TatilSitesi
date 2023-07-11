using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Globalization;
using TatilSitesi.Models;
using TatilSitesi.Repository;
using X.PagedList;

namespace TatilSitesi.Controllers
{
    [Authorize]
    public class HotelController : Controller
    {
        HotelRepository hr = new HotelRepository();
        public IActionResult HotelPage(int id)
        {
            var hotel = hr.Get(id);

            if (hotel != null)
            {
                hotel.HotelCount++;
                hr.Update(hotel);
            }
            ViewBag.Id = id;
            return View(hr.List("Category","City").Where(x => x.HotelId == id));
        }
        [AllowAnonymous]
        public IActionResult HotelPageNoComment(int id)
        {
            var hotel = hr.Get(id);
            if (hotel != null)
            {
                hotel.HotelCount++;
                hr.Update(hotel);
            }
            ViewBag.Id = id;
            return View(hr.List("Category", "City").Where(x => x.HotelId == id));
        }
        [AllowAnonymous]
        public IActionResult HotelListNoComment(int id, int page = 1)
        {
            HotelRepository hr = new HotelRepository();
            return View(hr.List("City", "Category").ToPagedList(page, 4));
        }
        [AllowAnonymous]
        public IActionResult HotelListHighPriceNoComment(int id, int page = 1)
        {
            HotelRepository hr = new HotelRepository();
            return View(hr.HighPriceHotelList("City", "Category").ToPagedList(page, 4));
        }
        [AllowAnonymous]
        public IActionResult HotelListLowPriceNoComment(int id, int page = 1)
        {
            HotelRepository hr = new HotelRepository();
            return View(hr.LowPriceHotelList("City", "Category").ToPagedList(page, 4));
        }
        [AllowAnonymous]
        public IActionResult HotelListMostCommentNoComment(int id, int page = 1)
        {
            HotelRepository hr = new HotelRepository();
            return View(hr.MostComment("City", "Category").ToPagedList(page, 4));
        }
        [AllowAnonymous]
        public IActionResult HotelListMostViewNoComment(int id, int page = 1)
        {
            HotelRepository hr = new HotelRepository();
            return View(hr.List("City", "Category").OrderByDescending(x => x.HotelCount).ToPagedList(page, 4));
        }
        [AllowAnonymous]
        public IActionResult HotelList5StarNoComment(int id, int page = 1)
        {
            HotelRepository hr = new HotelRepository();
            return View(hr.List("City", "Category").Where(x => x.HotelStar == 5).ToPagedList(page, 4));
        }
        [AllowAnonymous]
        public IActionResult HotelList4StarNoComment(int id, int page = 1)
        {
            HotelRepository hr = new HotelRepository();
            return View(hr.List("City", "Category").Where(x => x.HotelStar == 4).ToPagedList(page, 4));
        }
        [AllowAnonymous]
        public IActionResult HotelList3StarNoComment(int id, int page = 1)
        {
            HotelRepository hr = new HotelRepository();
            return View(hr.List("City", "Category").Where(x => x.HotelStar == 3).ToPagedList(page, 4));
        }
        [AllowAnonymous]
        public IActionResult HotelList2StarNoComment(int id, int page = 1)
        {
            HotelRepository hr = new HotelRepository();
            return View(hr.List("City", "Category").Where(x => x.HotelStar == 2).ToPagedList(page, 4));
        }
        [AllowAnonymous]
        public IActionResult HotelList1StarNoComment(int id, int page = 1)
        {
            HotelRepository hr = new HotelRepository();
            return View(hr.List("City", "Category").Where(x => x.HotelStar == 1).ToPagedList(page, 4));
        }
        [AllowAnonymous]
        public IActionResult HotelListRatingNoComment(int id, int page = 1)
        {
            HotelRepository hr = new HotelRepository();
            return View(hr.List("City", "Category").OrderByDescending(x => x.HotelRating).ToPagedList(page, 4));
        }
        [AllowAnonymous]
        public IActionResult HotelCategoryListNoComment(int id,int page = 1)
        {
            return View(hr.List("City", "Category").Where(x => x.CategoryId == id).ToPagedList(page, 4));

        }
        [AllowAnonymous]
        public IActionResult HotelCityListNoComment(int id, int page = 1)
        {
            return View(hr.List("City", "Category").Where(x => x.CityId == id).ToPagedList(page, 4));

        }
    }
}