using Microsoft.AspNetCore.Mvc;
using project_Zahar_home.Logic.Dishes;

namespace project_Zahar_home.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IDishManager _manager;

        public RecipesController(IDishManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> Index()
        {
            var dishes = await _manager.GetAll();
            return View(dishes);
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var dishes = await _manager.nameFilter(searchString);
            return View(dishes);
        }
    }
}
