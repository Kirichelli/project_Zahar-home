using Microsoft.AspNetCore.Mvc;
using project_Zahar_home.Logic.Dishes;
using project_Zahar_home.Logic.Ratings;
using project_Zahar_home.Models;
using project_Zahar_home.Storage.Entities;

namespace project_Zahar_home.Controllers
{
    public class DishController : Controller
    {
        private readonly IDishManager _dishManager;
        private readonly IRatingManager _ratingManager;
        private RecipeViewModel rvm;
        public DishController(IDishManager manager, IRatingManager ratingManager)
        {
            _dishManager = manager;
            _ratingManager = ratingManager; 
        }

        public async Task<IActionResult> Index(int dishId)
        {
            var dish = await _dishManager.getDish(dishId);
            var rating = await _ratingManager.GetDishRating(dish.Rating_Id);
            rvm = new RecipeViewModel { Dish = dish, Rating = rating };
            return View(rvm);
        }

        public async Task<IActionResult> ratingChange(int rating)
        {
            await _dishManager.changeRating(rvm.Rating.Rating_Id, rating);
            return View(rvm);
        }

    }
}
