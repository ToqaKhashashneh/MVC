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
    public class AdminController : Controller
    {
        private readonly MyDbContext _context;

        public AdminController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Admin
        public IActionResult Dashboard()
        {
            return View();
        }




        public async Task<IActionResult> Index() //For Products
        {
            return View(await _context.Products.ToListAsync());
        }



        public async Task<IActionResult> IndexUsers() //For Users
        {
            return View(await _context.Users.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id) //For Products
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


        public async Task<IActionResult> UserDetails(int? id)  //For Users
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }



        // GET: Admin/Create
        public IActionResult Create()    //For Products
        
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Description,Image")] Product product)  //For Products
        {

            _context.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult UserCreate() //For Users
       
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> UserCreate(User user) //For Users
        {

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexUsers));

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        

        [HttpPost]

        public IActionResult Edit(int id, [Bind("Id,Name,Price,Description,Image")] Product product)
        {
            
                _context.Update(product);
                 _context.SaveChanges();
            
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UserEdit(int? id) //Edit For Users (display)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }



        [HttpPost]
        public IActionResult UserEdit(int id, User user) //Handle Edit For Users
        {
                _context.Users.Update(user);
                 _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexUsers));

        }



        [HttpPost] //Delete For Users
        public IActionResult UserDelete(int id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("IndexUsers");
        }




        [HttpPost] //Delete For Products
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}
