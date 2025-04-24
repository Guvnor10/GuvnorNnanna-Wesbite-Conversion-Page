using GuvnorNnannaProject1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GuvnorNnannaProject1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult MassConversion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MassConversion(string kilograms)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(kilograms))
                {
                    ViewBag.Error = "Please enter a value.";
                    return View();
                }

                if (!double.TryParse(kilograms, out double kgValue))
                {
                    ViewBag.Error = "Invalid input. Please enter a numeric value.";
                    return View();
                }

                double pounds = kgValue * 2.20462;
                ViewBag.Kilograms = kgValue;
                ViewData["Pounds"] = pounds;
            }
            catch (Exception ex)
            {
                ViewData["Error"] = "Invalid input...";
            }

            return View();
        }
    }
}
