using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using System.Security.Claims;
using TatilSitesi.Models;
using TatilSitesi.Repository;
using X.PagedList;

namespace TatilSitesi.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        CommentRepository cr = new CommentRepository();
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
        public IActionResult CommentList(string p, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View("~/Views/Comment/CommentList.cshtml", cr.List("User", "Hotel").Where(x => (x.CommentText.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower()))))).ToPagedList(page, 12));
            }
            return View(cr.List("User","Hotel").ToPagedList(page, 12));
        }
        public IActionResult AdminCommentAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminCommentAdd(Comment c)
        {
            c.CommentDate = DateTime.Today;
            c.CommentStatu = true;
            cr.Add(c);
            return RedirectToAction("CommentList");

        }
        public IActionResult CommentDelete(int id)
        {
            cr.Delete(new Comment { CommentId = id });
            return RedirectToAction("CommentList");
        }
        public IActionResult CommentUpdate(Comment c)
        {
            var comment = cr.Get(c.CommentId);
            comment.CommentId = c.CommentId;
            comment.CommentText = c.CommentText;
            comment.CommentDate = c.CommentDate;
            comment.CommentStatu = c.CommentStatu;
            comment.HotelId = c.HotelId;
            comment.UserId = c.UserId;
            cr.Update(comment);
            return RedirectToAction("CommentList");
        }
        public IActionResult GetComment(int id)
        {
            var comment = cr.Get(id);
            Comment c = new Comment()
            {
                CommentId = comment.CommentId,
                CommentText = comment.CommentText,
                CommentDate = comment.CommentDate,
                CommentStatu = comment.CommentStatu,
                HotelId = comment.HotelId,
                UserId = comment.UserId,

            };
            UserRepository ur = new UserRepository();
            HotelRepository hr = new HotelRepository();

            var users = ur.List();
            var hotels = hr.List();

            var userItems = users.Select(c => new SelectListItem
            {
                Value = c.UserId.ToString(),
                Text = c.UserName
            }).ToList();
            var hotelItems = hotels.Select(c => new SelectListItem
            {
                Value = c.HotelId.ToString(),
                Text = c.HotelName
            }).ToList();

            ViewBag.Users = userItems;
            ViewBag.Hotels = hotelItems;

            return View(c);
        }
    }
}
