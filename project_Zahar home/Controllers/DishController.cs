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
        /*private RecipeViewModel rvm;*/
        public DishController(IDishManager manager, IRatingManager ratingManager)
        {
            _dishManager = manager;
            _ratingManager = ratingManager; 
        }

        public async Task<IActionResult> Index(int dishId)
        {
            var dish = await _dishManager.getDish(dishId);
            var rating = await _ratingManager.GetDishRating(dish.Rating_Id);
            ViewBag.dish = dish;
            ViewBag.rating = rating;
            return View();
        }

        public async Task<IActionResult> ratingChange(int rating)
        {
            await _dishManager.changeRating(ViewBag.rating.Rating_Id, rating, HttpContext.User.Identity.Name);
            return RedirectToAction("Index");
        }

    }
}
