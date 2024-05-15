using Microsoft.AspNetCore.Mvc;
using MVC_Identity.Models;
using System.Diagnostics;

namespace MVC_Identity.Controllers
{
    public class HomeController : Controller
    {
        private readonly IdentityDBContext _db;

        public HomeController(ILogger<HomeController> logger)
        {
            _db = new IdentityDBContext();
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AppUser appUser)
        {
            foreach(AppUser a in _db.AppUsers.ToList())
            {
                if((a.UserName == appUser.UserName) && (a.Password == appUser.Password) )                {
                    TempData["Success"] = "Hosgeldin " + appUser.UserName;
                    return RedirectToAction("Login");
                }
            }

            TempData["Error"] = "Hatali kullanici bilgileri";

            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }


    }
}
