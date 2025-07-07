using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ML3.Models;

namespace ML3.Controllers
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
        public IActionResult Choice()
        {
            return View(); // This should return a view with your choices.
        }
        public IActionResult Choice2()
        {
            return View(); // This should return a view with your choices.
        }
    }
}
