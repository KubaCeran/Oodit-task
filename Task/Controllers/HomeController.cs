using Microsoft.AspNetCore.Mvc;
using System.Text;
using Task.Helpers;
using Task.Models;

namespace Task.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            InputModel model = new InputModel();
            return View(model);
        }
        
       [HttpPost]
        public ActionResult Submit(InputModel model)
        {

            if(String.IsNullOrEmpty(model.Input))
            {
                ViewBag.Output = "[]";
                return View("Index");
            }

            var splitArray = HelperMethods.modifyInput(model.Input);

            if (!HelperMethods.isCorrect(splitArray))
            {
                ViewBag.Output = "Error";
                return View("Index");
            }
            
            var numbers = HelperMethods.modifyArray(splitArray);

            var final = HelperMethods.Counter(numbers);

            ViewBag.Output = $"[{final}]";

            return View("Index");
        }
    }
}