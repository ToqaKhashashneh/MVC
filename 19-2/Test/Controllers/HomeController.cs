using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Products()
        {
            return View();
        }

        public IActionResult ProductsDetails()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SetCookie()
        {
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(30),
            };

            Response.Cookies.Append("UserName", "Ahmed", options);
            Response.Cookies.Append("UserRole", "Admin", options);



            string userName = Request.Cookies["UserName"];
            string userRole = Request.Cookies["UserRole"];

            if (userName != null)
            {
                ViewBag.User = userName;
                ViewBag.Role = userRole;

            }
            else
            {
                ViewBag.Messege = "Not found";
            }

            return View();

        }

        public IActionResult DeleteCookie()
        {
            Response.Cookies.Delete("UserName");
            Response.Cookies.Delete("UserRole");
            return RedirectToAction("SetCookie");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
