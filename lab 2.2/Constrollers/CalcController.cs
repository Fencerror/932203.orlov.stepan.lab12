using Microsoft.AspNetCore.Mvc;

namespace lab_2._2.Controllers
{
    public class CalcController : Controller
    {
        // Страница с формой для Manual parsing в одной действии
        public IActionResult ManualParsingSingle()
        {
            return View();
        }

        // Обработка формы с Manual parsing в одной действии
        [HttpPost]
        public IActionResult ManualParsingSingle(double num1, string operation, double num2)
        {
            double? result = null;
            string errorMessage = null;

            switch (operation)
            {
                case "add":
                    result = num1 + num2;
                    break;
                case "subtract":
                    result = num1 - num2;
                    break;
                case "multiply":
                    result = num1 * num2;
                    break;
                case "divide":
                    if (num2 != 0)
                        result = num1 / num2;
                    else
                        errorMessage = "Division by zero is not allowed.";
                    break;
                default:
                    errorMessage = "Invalid operation.";
                    break;
            }

            ViewBag.Result = result;
            ViewBag.ErrorMessage = errorMessage;
            return View();
        }

        // Страница для Manual parsing в отдельных действиях
        public IActionResult ManualParsingSeparate()
        {
            return View();
        }

        // Обработка первой части Manual parsing (num1)
        [HttpPost]
        public IActionResult ManualParsingSeparateFirst(double num1)
        {
            ViewBag.Num1 = num1;
            return View("ManualParsingSeparate");
        }

        // Обработка второй части Manual parsing (num2 и operation)
        [HttpPost]
        public IActionResult ManualParsingSeparateSecond(double num2, string operation)
        {
            double? result = null;
            string errorMessage = null;
            double num1 = (double)ViewBag.Num1;

            switch (operation)
            {
                case "add":
                    result = num1 + num2;
                    break;
                case "subtract":
                    result = num1 - num2;
                    break;
                case "multiply":
                    result = num1 * num2;
                    break;
                case "divide":
                    if (num2 != 0)
                        result = num1 / num2;
                    else
                        errorMessage = "Division by zero is not allowed.";
                    break;
                default:
                    errorMessage = "Invalid operation.";
                    break;
            }

            ViewBag.Result = result;
            ViewBag.ErrorMessage = errorMessage;
            return View("ManualParsingSeparate");
        }

        // Страница для Model Binding (parameters)
        public IActionResult ModelBindingParameters()
        {
            return View();
        }

        // Обработка Model Binding для параметров
        [HttpPost]
        public IActionResult ModelBindingParameters(double num1, string operation, double num2)
        {
            double? result = null;
            string errorMessage = null;

            switch (operation)
            {
                case "add":
                    result = num1 + num2;
                    break;
                case "subtract":
                    result = num1 - num2;
                    break;
                case "multiply":
                    result = num1 * num2;
                    break;
                case "divide":
                    if (num2 != 0)
                        result = num1 / num2;
                    else
                        errorMessage = "Division by zero is not allowed.";
                    break;
                default:
                    errorMessage = "Invalid operation.";
                    break;
            }

            ViewBag.Result = result;
            ViewBag.ErrorMessage = errorMessage;
            return View();
        }

        // Страница для Model Binding с отдельной моделью
        public IActionResult ModelBindingSeparateModel()
        {
            return View();
        }

        // Обработка Model Binding с отдельной моделью
        [HttpPost]
        public IActionResult ModelBindingSeparateModel(CalculationModel model)
        {
            double? result = null;
            string errorMessage = null;

            switch (model.Operation)
            {
                case "add":
                    result = model.Num1 + model.Num2;
                    break;
                case "subtract":
                    result = model.Num1 - model.Num2;
                    break;
                case "multiply":
                    result = model.Num1 * model.Num2;
                    break;
                case "divide":
                    if (model.Num2 != 0)
                        result = model.Num1 / model.Num2;
                    else
                        errorMessage = "Division by zero is not allowed.";
                    break;
                default:
                    errorMessage = "Invalid operation.";
                    break;
            }

            ViewBag.Result = result;
            ViewBag.ErrorMessage = errorMessage;
            return View();
        }
    }

    // Модель для Model Binding с отдельной моделью
    public class CalculationModel
    {
        public double Num1 { get; set; }
        public double Num2 { get; set; }
        public string Operation { get; set; }
    }
}
