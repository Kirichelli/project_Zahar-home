using Microsoft.AspNetCore.Mvc;
using project_Zahar_home.Logic.Dishes;
using project_Zahar_home.Storage.Entities;

namespace project_Zahar_home.Controllers
{
    public class DishController : Controller
    {
        private readonly IDishManager _manager;
        private Dish _dish;
        public DishController(IDishManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> Index(int id)
        {
            _dish = await _manager.getDish(id);
            return View(_dish);
        }

        public async Task<IActionResult> ratingChange(int rating)
        {
            await _manager.changeRating(_dish.Rating_Id, rating);
            return View(_dish);
        }

    }
}
