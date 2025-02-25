using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Model_Lec3__25_2_.Models;

namespace Model_Lec3__25_2_.Controllers
{
    public class UserController : Controller
    {
        private readonly MyDbContext _context;

        public UserController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.msg = HttpContext.Session.GetString("UserName");

            return View( );
        }

 

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(User u)
        {
            _context.Add(u);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        //[HttpPost]
        //public IActionResult Create(Register reg)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(reg);
        //        _context.SaveChanges();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(reg);
        //}

        public IActionResult Login()
        {
            return View();
        }


       

        [HttpPost]
        public IActionResult Login(string Email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == Email && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetString("UserName", user.Email);
                return RedirectToAction("Index");
            }

          return View();
        }


        
            
      
    }
}
