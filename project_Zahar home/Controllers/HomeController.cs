using Microsoft.AspNetCore.Mvc;
using project_Zahar_home.Models;
using System.Diagnostics;

namespace project_Zahar_home.Controllers
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

        public IActionResult Error_404()
        {
            return View();
        }

        public IActionResult Inf_dish()
        {
            return View();
        }

        public IActionResult Info()
        {
            return View();
        }

        public IActionResult Personal_account()
        {
            return View();
        }

        public IActionResult Recipes()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}