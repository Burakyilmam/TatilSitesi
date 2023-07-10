using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TatilSitesi.Models;
using TatilSitesi.Repository;

namespace TatilSitesi.Controllers
{
    public class UserController : Controller
    {
        UserRepository ur = new UserRepository();
        Context c = new Context();
        public IActionResult UserPage(User u)
        {
            var adminIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(adminIdClaim))
            {
                int userId = int.Parse(adminIdClaim);
                Context c = new Context();
                var user = c.Users.FirstOrDefault(x => x.UserId == userId && x.UserStatu);
                if (user != null)
                {
                    var username = User.Identity.Name;
                    ViewBag.Name = username;
                    ViewBag.Id = userId;
                    return View();

                }
            }
            return RedirectToAction("UserLogin", "User");
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult UserLogin()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> UserLogin(User u)
        {
            var value = c.Users.FirstOrDefault(x => x.UserName == u.UserName && x.UserPassword == u.UserPassword && x.UserStatu);
            if (value != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,u.UserName),
                    new Claim(ClaimTypes.NameIdentifier, value.UserId.ToString())
                };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal pr = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(pr);
                return RedirectToAction("HomePage", "Home");
            }
            return View();
        }
        public async Task<IActionResult> UserLogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("HomePageNoComment", "Home");
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult UserRegister()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult UserRegister(User u)
        {
            u.UserStatu = true;
            u.UserEmail = "";
            u.UserGender = "";
            u.UserSurname = "";
            u.UserRealName = "";
            u.UserPhoneNumber = "";
            ur.Add(u);
            return RedirectToAction("UserLogin", "User");
        }
    }
}
