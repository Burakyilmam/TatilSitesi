using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using TatilSitesi.Repository;

namespace TatilSitesi.Controllers
{
    public class AppointmentController : Controller
    {
        HotelRoomRepository hr = new HotelRoomRepository();
        public IActionResult Index(int id)
        {
            return View(hr.List("Hotel").Where(x => x.HotelRoomId == id));
        }
    }
}