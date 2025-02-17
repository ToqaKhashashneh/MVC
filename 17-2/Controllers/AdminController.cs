using Microsoft.AspNetCore.Mvc;

namespace _17_2.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
