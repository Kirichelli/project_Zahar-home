using Microsoft.AspNetCore.Mvc;
using project_Zahar_home.Logic.Dishes;
using project_Zahar_home.Logic.Ratings;
using project_Zahar_home.Models;

namespace project_Zahar_home.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IDishManager _dishManager;
        private readonly IRatingManager _ratingManager;
/*        private IList<RecipeViewModel>rvm;*/

        public RecipesController(IDishManager manager, IRatingManager ratingManager)
        {
            _dishManager = manager;
            _ratingManager = ratingManager;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.rvm = new List<RecipeViewModel>();
            var dishes = await _dishManager.GetAll();
            foreach (var dish in dishes)
            {
                ViewBag.rvm.Add(new RecipeViewModel { Dish = dish, Rating = await _ratingManager.GetDishRating(dish.Rating_Id) });
            }
            return View();
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var dishes = await _dishManager.nameFilter(searchString);
            foreach (var dish in dishes)
            {
                ViewBag.rvm.Add(new RecipeViewModel { Dish = dish, Rating = await _ratingManager.GetDishRating(dish.Rating_Id) });
            }
            return View();
        }
    }
}
