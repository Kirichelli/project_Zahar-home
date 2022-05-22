using Microsoft.AspNetCore.Mvc;
using project_Zahar_home.Logic.Dishes;
using project_Zahar_home.Storage.Entities;

namespace project_Zahar_home.Controllers
{
    public class DishController : Controller
    {
        private readonly IDishManager _manager;
        private IList<Dish> dishes;
        public DishController(IDishManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> Index(int id)
        {
            var dish = await _manager.getDish(id);
            return View(dish);
        }

    }
}
