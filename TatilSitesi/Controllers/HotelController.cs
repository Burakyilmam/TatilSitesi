using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IActionResult HotelPage(string p, int id, int page = 1)
        {
            var hotel = hr.Get(id);

            if (hotel != null)
            {
                hotel.HotelCount++;
                hr.Update(hotel);
            }
            ViewBag.Id = id;

            if (!string.IsNullOrEmpty(p))
            {
                return View("~/Views/Hotel/HotelListNoComment.cshtml", hr.List("City", "Category").Where(x => (x.HotelName.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower()))))).ToPagedList(page, 12));
            }

            return View(hr.List("Category", "City").Where(x => x.HotelId == id));
        }
        [AllowAnonymous]
        public IActionResult HotelPageNoComment(string p, int id, int page = 1)
        {
            var hotel = hr.Get(id);
            if (hotel != null)
            {
                hotel.HotelCount++;
                hr.Update(hotel);
            }
            ViewBag.Id = id;

            if (!string.IsNullOrEmpty(p))
            {
                return View("~/Views/Hotel/HotelListNoComment.cshtml", hr.List("City", "Category").Where(x => (x.HotelName.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower()))))).ToPagedList(page, 12));
            }

            return View(hr.List("Category", "City").Where(x => x.HotelId == id));
        }
        [AllowAnonymous]
        public IActionResult HotelListNoComment(string p, int id, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(hr.List("City", "Category").Where(x => (x.HotelName.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower()))))).ToPagedList(page, 12));
            }

            return View(hr.List("City", "Category").ToPagedList(page, 4));
        }

        [AllowAnonymous]
        public IActionResult HotelListHighPriceNoComment(string p, int id, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(hr.HighPriceHotelList("City", "Category").Where(x => (x.HotelName.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower()))))).ToPagedList(page, 12));
            }

            return View(hr.HighPriceHotelList("City", "Category").ToPagedList(page, 4));
        }
        [AllowAnonymous]
        public IActionResult HotelListLowPriceNoComment(string p, int id, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(hr.LowPriceHotelList("City", "Category").Where(x => (x.HotelName.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower()))))).ToPagedList(page, 12));
            }
            return View(hr.LowPriceHotelList("City", "Category").ToPagedList(page, 4));
        }
        [AllowAnonymous]
        public IActionResult HotelListMostCommentNoComment(string p, int id, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(hr.MostComment("City", "Category").Where(x => (x.HotelName.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower()))))).ToPagedList(page, 12));
            }
            return View(hr.MostComment("City", "Category").ToPagedList(page, 4));
        }
        [AllowAnonymous]
        public IActionResult HotelListMostViewNoComment(string p, int id, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(hr.List("City", "Category").Where(x => (x.HotelName.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower()))))).OrderByDescending(x => x.HotelCount).ToPagedList(page, 12));
            }
            return View(hr.List("City", "Category").OrderByDescending(x => x.HotelCount).ToPagedList(page, 4));
        }
        [AllowAnonymous]
        public IActionResult HotelList5StarNoComment(string p, int id, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(hr.List("City", "Category").Where(x => (x.HotelName.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower()))))).ToPagedList(page, 12));
            }
            return View(hr.List("City", "Category").Where(x => x.HotelStar == 5).ToPagedList(page, 4));
        }
        [AllowAnonymous]
        public IActionResult HotelList4StarNoComment(string p, int id, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(hr.List("City", "Category").Where(x => (x.HotelName.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower()))))).ToPagedList(page, 12));
            }
            return View(hr.List("City", "Category").Where(x => x.HotelStar == 4).ToPagedList(page, 4));
        }
        [AllowAnonymous]
        public IActionResult HotelList3StarNoComment(string p, int id, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(hr.List("City", "Category").Where(x => (x.HotelName.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower()))))).ToPagedList(page, 12));
            }
            return View(hr.List("City", "Category").Where(x => x.HotelStar == 3).ToPagedList(page, 4));
        }
        [AllowAnonymous]
        public IActionResult HotelList2StarNoComment(string p, int id, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(hr.List("City", "Category").Where(x => (x.HotelName.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower()))))).ToPagedList(page, 12));
            }
            return View(hr.List("City", "Category").Where(x => x.HotelStar == 2).ToPagedList(page, 4));
        }
        [AllowAnonymous]
        public IActionResult HotelList1StarNoComment(string p, int id, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(hr.List("City", "Category").Where(x => (x.HotelName.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower()))))).ToPagedList(page, 12));
            }
            return View(hr.List("City", "Category").Where(x => x.HotelStar == 1).ToPagedList(page, 4));
        }
        [AllowAnonymous]
        public IActionResult HotelListStarNoComment(string p, int id, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(hr.List("City", "Category").Where(x => (x.HotelName.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower()))))).OrderByDescending(x => x.HotelStar).ToPagedList(page, 12));
            }
            return View(hr.List("City", "Category").OrderByDescending(x => x.HotelStar).ToPagedList(page, 4));
        }
        [AllowAnonymous]
        public IActionResult HotelListRatingNoComment(string p, int id, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(hr.List("City", "Category").Where(x => (x.HotelName.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower()))))).OrderByDescending(x => x.HotelRating).ToPagedList(page, 12));
            }
            return View(hr.List("City", "Category").OrderByDescending(x => x.HotelRating).ToPagedList(page, 4));
        }
        [AllowAnonymous]
        public IActionResult HotelCategoryListNoComment(string p, int id, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(hr.List("City", "Category").Where(x => (x.HotelName.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower()))))).OrderByDescending(x => x.HotelName).ToPagedList(page, 12));
            }
            return View(hr.List("City", "Category").Where(x => x.CategoryId == id).OrderByDescending(x => x.HotelName).ToPagedList(page, 4));

        }
        [AllowAnonymous]
        public IActionResult HotelCityListNoComment(string p, int id, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(hr.List("City", "Category").Where(x => (x.HotelName.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower()))))).OrderByDescending(x => x.HotelName).ToPagedList(page, 12));
            }
            return View(hr.List("City", "Category").Where(x => x.CityId == id).OrderByDescending(x => x.HotelName).ToPagedList(page, 4));

        }

        // <------------------ Admin Tarafı ------------------>
        public IActionResult HotelAdminList(string p ,int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View("~/Views/Hotel/HotelAdminList.cshtml", hr.List("Category","City").Where(x => (x.HotelName.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower()))))).ToPagedList(page, 12));
            }
            return View(hr.List("Category", "City").ToPagedList(page, 12));
        }
        [HttpGet]
        public IActionResult HotelAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult HotelAdd(Hotel m)
        {
            bool isHotelExists = hr.CheckHotelName(m.HotelName);

            if (!isHotelExists)
            {
                m.HotelCount = 0;
                m.HotelStatu = true;
                hr.Add(m);
                return RedirectToAction("HotelAdminList");
            }
            else
            {
                ViewData["ErrorMessage"] = "Otel Adı Kullanılmaktadır. Lütfen Aşağıdaki Alana Veritabanında Bulunmayan Bir Otel Adı Yazınız.";
                return View();
            }
        }
        public IActionResult HotelDelete(int id)
        {
            hr.Delete(new Hotel { HotelId = id });
            return RedirectToAction("HotelAdminList");
        }
        public IActionResult HotelUpdate(Hotel m)
        {
            var hotel = hr.Get(m.HotelId);
            hotel.HotelName = m.HotelName;
            hotel.HotelDescription = m.HotelDescription;
            hotel.CategoryId = m.CategoryId;
            hotel.CityId = m.CityId;
            hotel.HotelThumbnailImageUrl = m.HotelThumbnailImageUrl;
            hotel.HotelRating = m.HotelRating;
            hotel.HotelStar = m.HotelStar;
            hotel.HotelCount = m.HotelCount;
            hotel.HotelStatu = m.HotelStatu;
            hotel.HotelAddress = m.HotelAddress;
            hr.Update(hotel);
            return RedirectToAction("HotelAdminList");
        }
        public IActionResult GetHotel(int id)
        {
            var hotel = hr.Get(id);
            Hotel m = new Hotel()
            {
                HotelId = hotel.HotelId,
                HotelName = hotel.HotelName,
                HotelAddress = hotel.HotelAddress,
                HotelCount = hotel.HotelCount,
                HotelDescription = hotel.HotelDescription,
                HotelRating = hotel.HotelRating,
                HotelStar = hotel.HotelStar,
                HotelStatu = hotel.HotelStatu,
                HotelThumbnailImageUrl = hotel.HotelThumbnailImageUrl,
                CityId = hotel.CityId,
                CategoryId = hotel.CategoryId,
            };
            CategoryRepository cat = new CategoryRepository();
            CityRepository cr = new CityRepository();

            var categories = cat.List();
            var cities = cr.List();

            var categoryItems = categories.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.CategoryName
            }).ToList();
            var cityItems = cities.Select(c => new SelectListItem
            {
                Value = c.CityId.ToString(),
                Text = c.CityName
            }).ToList();

            ViewBag.Categories = categoryItems;
            ViewBag.Cities = cityItems;

            return View(m);
        }
        public IActionResult GetUpdate(int id)
        {
            var hotel = hr.Get(id);
            Hotel m = new Hotel()
            {
                HotelId = hotel.HotelId,
                HotelName = hotel.HotelName,
                HotelAddress = hotel.HotelAddress,
                HotelCount = hotel.HotelCount,
                HotelDescription = hotel.HotelDescription,
                HotelRating = hotel.HotelRating,
                HotelStar = hotel.HotelStar,
                HotelStatu = hotel.HotelStatu,
                HotelThumbnailImageUrl = hotel.HotelThumbnailImageUrl,
                CityId = hotel.CityId,
                CategoryId = hotel.CategoryId,
            };
            CategoryRepository cat = new CategoryRepository();
            CityRepository cr = new CityRepository();

            var categories = cat.List();
            var cities = cr.List();

            var categoryItems = categories.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.CategoryName
            }).ToList();
            var cityItems = cities.Select(c => new SelectListItem
            {
                Value = c.CityId.ToString(),
                Text = c.CityName
            }).ToList();

            ViewBag.Categories = categoryItems;
            ViewBag.Cities = cityItems;
            return View(m);
        }

    }
    }
