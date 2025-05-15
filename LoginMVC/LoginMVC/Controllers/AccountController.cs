using LoginMVC.FakeDB;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LoginMVC.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = fakeUserDB.Users
                .FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, username)
                            };
                HttpContext.Session.SetString("User", user.Username);
                var identity = new ClaimsIdentity(claims, "Cookies");
                var principal = new ClaimsPrincipal(identity);

                HttpContext.SignInAsync("Cookies", principal);

                return RedirectToAction("Index", "Home");

                
            }

            ViewBag.Error = "Credenciales inválidas";
            return View();
        }

        public ActionResult Welcome()
        {
            if (HttpContext.Session.GetString("User") == null)
                return RedirectToAction("Login");

            ViewBag.User = HttpContext.Session.GetString("User").ToString();
            return View();
        }


        public IActionResult Logout()
        {
            HttpContext.SignOutAsync("Cookies");
            return RedirectToAction("Login");
        }
    }


}

