using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Models;

namespace E_Commerce.Controllers
{
    public class UsersController : Controller
    {
        private readonly MyDbContext _context;

        public UsersController(MyDbContext context)
        {
            _context = context;
        }

       
        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }



        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }




        public IActionResult Create() //For Register
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken] //Handle Register
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Password,Role")] User user)
        {

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Login");

        }



        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var userinfo = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

            if (userinfo != null)
            {

                HttpContext.Session.SetString("UserName", userinfo.Name);
                HttpContext.Session.SetString("UserRole", userinfo.Role);
                HttpContext.Session.SetString("UserEmail", userinfo.Email);

                if (userinfo.Role == "Admin")
                {
                    return RedirectToAction("Dashboard", "Admin");
                }
                return RedirectToAction("Index", "Users");

            }


            ViewBag.Msg1 = "Invalid Email or Password";
            return View();
        }



        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }




        public IActionResult Profile()
        {



            var email = HttpContext.Session.GetString("UserEmail");

            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            return View(user);
        }



        public IActionResult EditProfile()
        {
            var email = HttpContext.Session.GetString("UserEmail");


            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            return View(user);
        }


        [HttpPost]
        public IActionResult EditProfile(User updateuser)
        {
            var email = HttpContext.Session.GetString("UserEmail");


            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            user.Name = updateuser.Name;
            user.Email = updateuser.Email;
            _context.SaveChanges();
            HttpContext.Session.SetString("UserEmail", updateuser.Email);
            ViewBag.msg2 = "Update seccessfully";

            return RedirectToAction("Profile");
        }









    }
}
