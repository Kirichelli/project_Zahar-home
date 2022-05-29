using Microsoft.AspNetCore.Mvc;
using project_Zahar_home.Logic.Dishes;
using project_Zahar_home.Logic.Ratings;
using project_Zahar_home.Logic.Users;
using project_Zahar_home.Models;
using System.Diagnostics;

namespace project_Zahar_home.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDishManager _dishManager;
        private readonly IRatingManager _ratingManager;
        public HomeController(ILogger<HomeController> logger, IDishManager dishManager, IRatingManager ratingManager)
        {
            _logger = logger;
            _dishManager = dishManager;
            _ratingManager = ratingManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Recipes()
        {
            return View();
        }
        public IActionResult Info()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Error_404()
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