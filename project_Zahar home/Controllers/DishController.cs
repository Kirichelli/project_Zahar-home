using Microsoft.AspNetCore.Mvc;
using project_Zahar_home.Logic.Cooked;
using project_Zahar_home.Logic.Dishes;
using project_Zahar_home.Logic.Ratings;
using project_Zahar_home.Storage.Entities;

namespace project_Zahar_home.Controllers
{
    public class DishController : Controller
    {
        private readonly IDishManager _dishManager;
        private readonly IRatingManager _ratingManager;
        private readonly ICookedManagercs _cookedManager;
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
        

        

/*        public ActionResult Report(Dish dish)
        {
            DishReport dishReport = new DishReport();
            byte[] abytes = dishReport.PrepareReport();
            return File(abytes,"application/pdf");
        }

        public List<Dish> GetDishes()
        {
            List<Dish> dishes = new List<Dish>();
            Dish dish = new Dish();
            for (int i = 1; i <=4; i++)
            {
                dish = new Dish();
                dish.Dish_Id = i;
                dish.Name_Dish = name;
            }
        }*/
    }
}
