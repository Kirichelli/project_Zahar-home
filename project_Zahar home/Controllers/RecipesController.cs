using Microsoft.AspNetCore.Mvc;
using project_Zahar_home.Logic.Dishes;

namespace project_Zahar_home.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IDishManager _dishManager;
        public RecipesController(IDishManager manager)
        {
            _dishManager = manager;
        }

        public async Task<IActionResult> Index()
        {
            var dishes = await _dishManager.GetAll();
            return View(dishes);
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var dishes = await _dishManager.nameFilter(searchString);
            return View(dishes);
        }
    }
}
