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
        private List<RecipeViewModel> rvm;
        public RecipesController(IDishManager manager, RatingManager ratingManager)
        {
            _dishManager = manager;
            _ratingManager = ratingManager;
        }

        public async Task<IActionResult> Index()
        {
            rvm = new List<RecipeViewModel>();
            var dishes = await _dishManager.GetAll();
            var ratings = await _ratingManager.GetRatings();
            foreach (var dis in dishes)
            {
                rvm.Add(new RecipeViewModel { Dish = dis, Rating = ratings.FirstOrDefault(r => r.Rating_Id == dis.Rating_id) });
            }
            return View(rvm);
        }

        public async Task<IActionResult> Index(string searchString)
        {
            rvm = new List<RecipeViewModel>();
            var dishes = await _dishManager.nameFilter(searchString);
            var ratings = await _ratingManager.GetRatings();
            foreach (var dis in dishes)
            {
                rvm.Add(new RecipeViewModel { Dish = dis, Rating = ratings.FirstOrDefault(r => r.Rating_Id == dis.Rating_id) });
            }
            return View(rvm);
        }
    }
}
