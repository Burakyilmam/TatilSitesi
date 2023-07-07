using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using TatilSitesi.Models;
using TatilSitesi.Repository;

namespace TatilSitesi.Controllers
{
    public class CommentController : Controller
    {
        CommentRepository cr = new CommentRepository();
        public IActionResult CommentList()
        {
            {
                return View(cr.List("Hotel", "User").Where(x => x.CommentDate <= DateTime.Now).OrderBy(x => x.HotelId));
            }
        }
        [HttpGet]
        public IActionResult CommentAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CommentAdd(Comment c)
        {
            c.CommentDate = DateTime.Today;
            c.CommentStatu = true;
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(userIdClaim))
            {
                int userId = int.Parse(userIdClaim);
                c.UserId = userId;
            }
            cr.Add(c);
            return RedirectToAction("HotelPage", "Hotel", new { @id = c.HotelId });

        }
    }
}
