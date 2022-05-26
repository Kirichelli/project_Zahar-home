using Microsoft.AspNetCore.Mvc;
using project_Zahar_home.Logic.Dishes;
using project_Zahar_home.Logic.Ratings;
using project_Zahar_home.Models;
using project_Zahar_home.Storage.Entities;

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
            ViewBag.rvm = new Dictionary<Dish,Rating>();
            var dishes = await _dishManager.GetAll();
            foreach (var dish in dishes)
            {
                ViewBag.rvm.Add(dish, await _ratingManager.GetDishRating(dish.Rating_Id));
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            ViewBag.rvm = new Dictionary<Dish, Rating>();
            var dishes = await _dishManager.nameFilter(searchString);
            foreach (var dish in dishes)
            {
                ViewBag.rvm.Add(dish, await _ratingManager.GetDishRating(dish.Rating_Id));
            }
            
            return View();
        }


        public IActionResult Index(string level, int? calloriesMin, int? calloriesMax, int? proteinMin, int? proteinMax, int? carbohydratMin, int? carbohydratMax, int? fatMin, int? fatMax, int? ratingOrder, string typeName)
        {
            IList<Dish> dishes = _dishManager.GetDishesByProperties(ViewBag.rvm.Values.ToList(), level, calloriesMin, calloriesMax, proteinMin, proteinMax, carbohydratMin, carbohydratMax, fatMin, fatMax, typeName);
            var ratings = _ratingManager.Sort(ViewBag.rvm.Keys.ToList(), ratingOrder);
            ViewBag.rvm = new Dictionary<Dish, Rating>();
            foreach(var r in ratings)
            {
                foreach(var dish in dishes)
                {
                    if (dish.Rating_Id == r.Rating_Id)
                    {
                        ViewBag.rvm.Add(dish,r);
                    }
                }
            }
            return View();
        }
    }
}
