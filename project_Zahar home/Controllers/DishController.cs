using Microsoft.AspNetCore.Mvc;
using project_Zahar_home.Logic.Cooked;
using project_Zahar_home.Logic.Dishes;
using project_Zahar_home.Logic.Favourites;
using project_Zahar_home.Logic.Ratings;

namespace project_Zahar_home.Controllers
{
    public class DishController : Controller
    {
        private readonly IDishManager _dishManager;
        private readonly IRatingManager _ratingManager;
        private readonly ICookedManagercs _cookedManager;
        private readonly IFavouriteManager _favouriteManager;
        /*private RecipeViewModel rvm;*/
        public DishController(IDishManager manager, IRatingManager ratingManager)
        {
            _dishManager = manager;
            _ratingManager = ratingManager; 
        }

        public async Task<IActionResult> Index(int dishId)
        {
            var dish = await _dishManager.getDish(dishId);
            var rating = await _ratingManager.GetDishRating(dish.Dish_Id);
            ViewBag.dish = dish;
            ViewBag.rating = rating;
            return View();
        }

        public async Task<IActionResult> ratingChange(int rating)
        {
            await _dishManager.changeRating(ViewBag.rating.Rating_Id, rating, HttpContext.User.Identity.Name);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddToFavourite()
        {
            _favouriteManager.Add(ViewBag.dish.Dish_Id, HttpContext.User.Identity.Name);
            return RedirectToAction("Index");
        }
    }
}
