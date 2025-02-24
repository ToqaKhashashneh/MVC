using Microsoft.AspNetCore.Mvc;
using Model_Lec2.Models;

namespace Model_Lec2.Controllers
{
    public class ProductController : Controller
    {

        private readonly MyDbContext _context;

        public ProductController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {

            _context.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int Id)
        {

            var PD = _context.Products.Find(Id);

            return View(PD);

        }


        public IActionResult Edit(int Id)
        {

            var PE = _context.Products.Find(Id);

            return View(PE);

        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();

            return RedirectToAction("Index");


        }


        public IActionResult Delete(int Id)
        {
            var PD = _context.Products.Find(Id);
            _context.Remove(PD);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }



    }
}
