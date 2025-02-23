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
        public IActionResult HandleLogin(string email , string password, string rem)
        {
            string userEmail = HttpContext.Session.GetString("UserEmail");
            string userPassword = HttpContext.Session.GetString("UserPassword");


            if (rem != null)
            {
                CookieOptions obj = new CookieOptions();
                obj.Expires = DateTime.Now.AddDays(2);
                Response.Cookies.Append("userInfo", userEmail, obj);
            }

            if (email == userEmail && password == userPassword)
            {
                HttpContext.Session.SetString("LoggerType", "User");
                return RedirectToAction("Index", "Home");

            }


            if (email == "Admin@gmail.com" && password == "000")
            {
                HttpContext.Session.SetString("Email", "Admin@gmail.com");
                HttpContext.Session.SetString("Password", "000");


                HttpContext.Session.SetString("LoggerType", "Admin");

                return RedirectToAction("Index", "Home");
            }
           
                TempData["LoginMsg"] = "Invalid Email or Password! Try Again.";
                return RedirectToAction("Login");
            




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
            ViewBag.UserPhone = HttpContext.Session.GetString("UserPhone");
            ViewBag.UserAddress = HttpContext.Session.GetString("UserAddress");
     
            return View();
        }


        public IActionResult HandleEdit()
        {
            // Process the form data here
            // Example: Save changes, update database or session
            //HttpContext.Session.SetString("UserName", name);
            //HttpContext.Session.SetString("UserPhone", phone);
            //HttpContext.Session.SetString("UserAddress", address);

            // Redirect after processing
            return RedirectToAction("Profile");
        }





        //public IActionResult ClearSession()
        //{
        //    HttpContext.Session.Clear(); 
        //    return RedirectToAction("Profile");

        //}
        //public IActionResult RemoveSession()
        //{
        //    HttpContext.Session.Remove("UserName");

        //    return RedirectToAction("Profile");

        //}

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Admin()
        {

            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Password = HttpContext.Session.GetString("Password");

            return View();
        }                                                                                                                            


    }



}
