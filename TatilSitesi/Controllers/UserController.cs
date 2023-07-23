    using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;
using TatilSitesi.Models;
using TatilSitesi.Repository;
using X.PagedList;

namespace TatilSitesi.Controllers
{
    [Authorize]
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
            bool isUserExists = ur.CheckUserName(u.UserName);

            if (!isUserExists)
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
            else
            {
                ViewData["ErrorMessage"] = "Kullanıcı Adı Kullanılmaktadır. Lütfen Aşağıdaki Alana Veritabanında Bulunmayan Bir Kullanıcı Adı Yazınız.";
                return View();
            }
        }
        public IActionResult UserList(string p, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View("~/Views/User/UserList.cshtml", ur.List().Where(x => (x.UserName.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower()))))).ToPagedList(page, 12));
            }
            return View(ur.List().ToPagedList(page, 12));
        }
        [HttpGet]
        public IActionResult UserAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UserAdd(User u)
        {
            bool isUserExists = ur.CheckUserName(u.UserName);

            if (!isUserExists)
            {
                u.UserStatu = true;
                ur.Add(u);
                return RedirectToAction("UserList");
            }
            else
            {
                ViewData["ErrorMessage"] = "Kullanıcı Adı Kullanılmaktadır.";
                return View();
            }
        }
        public IActionResult UserDelete(int id)
        {
            ur.Delete(new User { UserId = id });
            return RedirectToAction("UserList");
        }
        public IActionResult GetUser(int id)
        {
            var User = ur.Get(id);
            User c = new User()
            {
                UserId = User.UserId,
                UserRealName = User.UserRealName,
                UserSurname = User.UserSurname,
                UserGender = User.UserGender,
                UserPhoneNumber = User.UserPhoneNumber,
                UserEmail = User.UserEmail,
                UserName = User.UserName,
                UserPassword = User.UserPassword,
                UserStatu = User.UserStatu
            };
            return View(c);
        }
        public IActionResult UserUpdate(User c)
        {
            var User = ur.Get(c.UserId);
            User.UserRealName = c.UserRealName;
            User.UserSurname = c.UserSurname;
            User.UserGender = c.UserGender;
            User.UserPhoneNumber = c.UserPhoneNumber;
            User.UserEmail = c.UserEmail;
            User.UserName = c.UserName;
            User.UserPassword = c.UserPassword;
            User.UserStatu = c.UserStatu;
            User.UserId = c.UserId;
            ur.Update(User);
            return RedirectToAction("UserList");
        }
    }
}
