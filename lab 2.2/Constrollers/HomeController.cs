using Microsoft.AspNetCore.Mvc;
using lab_2._2.Models;

namespace lab_2._2.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MathOperation model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    switch (model.Operation)
                    {
                        case "Add":
                            model.Result = model.Number1 + model.Number2;
                            break;
                        case "Subtract":
                            model.Result = model.Number1 - model.Number2;
                            break;
                        case "Multiply":
                            model.Result = model.Number1 * model.Number2;
                            break;
                        case "Divide":
                            if (model.Number2 == 0)
                                throw new DivideByZeroException();
                            model.Result = model.Number1 / model.Number2;
                            break;
                        default:
                            model.ErrorMessage = "Invalid operation selected.";
                            break;
                    }
                }
                catch (DivideByZeroException)
                {
                    model.ErrorMessage = "Cannot divide by zero.";
                }
            }

            return View(model);
        }
    }
}
