using Microsoft.AspNetCore.Mvc;
using Model_Lec1.Models;

namespace Model_Lec1.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly MyDbContext _context;

        public DepartmentController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {    //Notes:
             //1. we can use the _context object to interact with the database

            // 2.here we are fetching all the departments from the database
            // i can store the departments in a variable and pass it to the view


            //var departments = _context.Departments.ToList();
            //return View(departments);

            // or directly pass the departments to the view 
            return View( _context.Departments.ToList());


        }


        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(Department department)
        {
            _context.Departments.Add(department);
            //other way to add:
            //_context.Add(department);

            _context.SaveChanges();
            return RedirectToAction("Index");
       
        }



    }
}
