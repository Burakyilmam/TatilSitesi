using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using TatilSitesi.Models;
using TatilSitesi.Repository;
using X.PagedList;

namespace TatilSitesi.Controllers
{
    [Authorize]
    public class CityController : Controller
    { 
        CityRepository cr = new CityRepository();
        public IActionResult CityList(string p, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View("~/Views/City/CityList.cshtml", cr.List().Where(x => (x.CityName.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower()))))).ToPagedList(page, 12));
            }
            return View(cr.List().ToPagedList(page, 12));
        }
        [HttpGet]
        public IActionResult CityAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CityAdd(City c)
        {
            c.CityStatu = true;
            cr.Add(c);
            return RedirectToAction("CityList");
        }
        public IActionResult CityDelete(int id)
        {
            cr.Delete(new City { CityId = id });
            return RedirectToAction("CityList");
        }
        public IActionResult GetCity(int id)
        {
            var City = cr.Get(id);
            City c = new City()
            {
                CityId = City.CityId,
                CityName = City.CityName,
                CityStatu = City.CityStatu
            };
            return View(c);
        }
        public IActionResult CityUpdate(City c)
        {
            var City = cr.Get(c.CityId);
            City.CityName = c.CityName;
            City.CityStatu = c.CityStatu;
            City.CityId = c.CityId;
            cr.Update(City);
            return RedirectToAction("CityList");
        }
    }
}
