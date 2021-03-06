using Microsoft.AspNetCore.Mvc;
using project_Zahar_home.Logic.Dishes;
using project_Zahar_home.Logic.Imgs;
using project_Zahar_home.Logic.Ratings;
using project_Zahar_home.Models;
using project_Zahar_home.Storage.Entities;

namespace project_Zahar_home.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IDishManager _dishManager;
        private readonly IRatingManager _ratingManager;
        private readonly IImgManager _imgManager;
        private static Dictionary<Dish, Rating> rvm;
        private static IList<Img> image;
        private static int _dishRatingId;

        public RecipesController(IDishManager manager, IRatingManager ratingManager, IImgManager imgManager)
        {
            _dishManager = manager;
            _ratingManager = ratingManager;
            _imgManager = imgManager;
        }
        public IActionResult Inf_dish(int id)
        {
            foreach (var dish in rvm)
            {
                if (dish.Key.Dish_Id == id)
                {
                    _dishRatingId = dish.Value.Rating_Id;
                    ViewBag.Dish = dish;
                    ViewBag.Image = image;
                    return View();
                }
            }
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            if (rvm == null)
            {
                rvm = new Dictionary<Dish, Rating>();
                var dishes = _dishManager.GetAll();
                foreach (var dish in dishes)
                {
                    rvm.Add(dish, _ratingManager.GetDishRating(dish.Dish_Id));
                }
                image = _imgManager.GetAll();
            }
            ViewBag.rvm = rvm;
            ViewBag.Image = image;
            return View();
        }
        [HttpPost]
        public IActionResult Search(string searchString)
        {
            rvm = new Dictionary<Dish, Rating>();
            var dishes = _dishManager.nameFilter(searchString);
            foreach (var dish in dishes)
            {
                rvm.Add(dish, _ratingManager.GetDishRating(dish.Dish_Id));
            }
            ViewBag.rvm = rvm;
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            rvm = null;
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> FilterAsync(string? level, int? calloriesMin, int? calloriesMax, int? proteinMin, int? proteinMax, int? carbohydratMin, int? carbohydratMax, int? fatMin, int? fatMax, int? ratingOrder, string? typeName)
        {
            IList<Dish> dishes = _dishManager.GetDishesByProperties(rvm.Keys.ToList(), level, calloriesMin, calloriesMax, proteinMin, proteinMax, carbohydratMin, carbohydratMax, fatMin, fatMax, typeName);
            var ratings = _ratingManager.Sort(rvm.Values.ToList(), ratingOrder);
            rvm = new Dictionary<Dish, Rating>();
            foreach(var r in ratings)
            {
                foreach(var dish in dishes)
                {
                    if (dish.Dish_Id == r.Dish_Id)
                    {
                        rvm.TryAdd(dish,r);
                    }
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ratingChange(int rating, int id)
        {
            _dishManager.changeRating(_dishRatingId, rating, HttpContext.User.Identity.Name);
            rvm = new Dictionary<Dish, Rating>();
            var dishes = _dishManager.GetAll();
            foreach (var dish in dishes)
            {
                rvm.Add(dish, _ratingManager.GetDishRating(dish.Dish_Id));
            }
            image = _imgManager.GetAll();
            return RedirectToAction("Inf_dish", new { id = id });
        }
    }
}
