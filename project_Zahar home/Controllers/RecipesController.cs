﻿using Microsoft.AspNetCore.Mvc;
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
        private static Dictionary<Dish, Rating> rvm;

        public RecipesController(IDishManager manager, IRatingManager ratingManager)
        {
            _dishManager = manager;
            _ratingManager = ratingManager;
        }
        public IActionResult Inf_dish(int id)
        {
            foreach (var dish in rvm)
            {
                if (dish.Key.Dish_Id == id)
                {
                    ViewBag.Dish = dish;
                    return View();
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Index()
        {
            if (rvm == null)
            {
                rvm = new Dictionary<Dish, Rating>();
                var dishes = await _dishManager.GetAll();
                foreach (var dish in dishes)
                {
                    rvm.Add(dish, await _ratingManager.GetDishRating(dish.Rating_Id));
                }
            }
            ViewBag.rvm = rvm;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Search(string searchString)
        {
            rvm = new Dictionary<Dish, Rating>();
            var dishes = await _dishManager.nameFilter(searchString);
            foreach (var dish in dishes)
            {
                rvm.Add(dish, await _ratingManager.GetDishRating(dish.Rating_Id));
            }
            ViewBag.rvm = rvm;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> FilterAsync(string? level, int? calloriesMin, int? calloriesMax, int? proteinMin, int? proteinMax, int? carbohydratMin, int? carbohydratMax, int? fatMin, int? fatMax, int? ratingOrder, string? typeName)
        {
            rvm = new Dictionary<Dish, Rating>();
            var dishess = await _dishManager.GetAll();
            foreach (var dish in dishess)
            {
                rvm.Add(dish, await _ratingManager.GetDishRating(dish.Rating_Id));
            }
            IList<Dish> dishes = _dishManager.GetDishesByProperties(rvm.Keys.ToList(), level, calloriesMin, calloriesMax, proteinMin, proteinMax, carbohydratMin, carbohydratMax, fatMin, fatMax, typeName);
            var ratings = _ratingManager.Sort(rvm.Values.ToList(), ratingOrder);
            rvm = new Dictionary<Dish, Rating>();
            foreach(var r in ratings)
            {
                foreach(var dish in dishes)
                {
                    if (dish.Rating_Id == r.Rating_Id)
                    {
                        rvm.TryAdd(dish,r);
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}
