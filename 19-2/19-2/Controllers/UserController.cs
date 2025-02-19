using Microsoft.AspNetCore.Mvc;

namespace _19_2.Controllers
{
    public class UserController : Controller
    {

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult HandleRegister(string name, string email , string password , string confpassword)
        {
            HttpContext.Session.SetString("UserName", name);
            HttpContext.Session.SetString("UserEmail", email);
            HttpContext.Session.SetString("UserPassword", password);
            HttpContext.Session.SetString("UserConfPassword", confpassword);

            if (password != confpassword)
            {
                TempData["RegisterMsg"] = "Password doesn't match! Try Again.";
                return RedirectToAction("Register");

            }
            else
            {
                return RedirectToAction("Login");

            }
        }
        [HttpPost]
        public IActionResult HandleLogin(string email , string password)
        {
            string userEmail = HttpContext.Session.GetString("UserEmail");
            string userPassword = HttpContext.Session.GetString("UserPassword");

            if (email == userEmail && password == userPassword)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["LoginMsg"] = "Invalid Email or Password! Try Again.";
                return RedirectToAction("Login");
            }
        }


        public IActionResult Login()
        {
            return View();
        }

        
        public IActionResult Profile()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");

            ViewBag.UserEmail = HttpContext.Session.GetString("UserEmail");
            ViewBag.UserPassword = HttpContext.Session.GetString("UserPassword");
            return View();
        }
    }
}
