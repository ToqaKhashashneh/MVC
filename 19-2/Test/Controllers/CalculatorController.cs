using Microsoft.AspNetCore.Mvc;

namespace Test.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Calc()
        {
            return View();
        }


        [HttpPost]
        public IActionResult HandleCalc(int number1, int number2, string operation)
        {


            int result = 0;
            switch (operation)
            {
                case "+":
                    result = number1 + number2;
                    break;
                case "-":
                    result = number1 - number2;
                    break;
                case "*":
                    result = number1 * number2;
                    break;
                case "/":

                    if (number2 == 0)
                    {
                        TempData["Message"] = "Error";
                        break;
                    }
                    result = number1 / number2;
                    break;

                default:
                    
                    TempData["Message"] = "Error";

                    return RedirectToAction("Calc");

            }

            TempData["Result"] = result;

            return RedirectToAction("Calc");
        }
    }

}
