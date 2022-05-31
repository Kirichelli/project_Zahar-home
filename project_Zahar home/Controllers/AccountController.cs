using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using project_Zahar_home.Logic.Dishes;
using project_Zahar_home.Logic.Users;
using project_Zahar_home.Logic.Ratings;
using project_Zahar_home.Models;
using project_Zahar_home.Storage.Entities;
using System.Security.Claims;
using project_Zahar_home.Logic.Cooked;

namespace project_Zahar_home.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly IDishManager _dishManager;
        private readonly IRatingManager _ratingManager;
        private readonly ICookedManagercs _cookedManager;
        private static Dictionary<Dish, Rating> rvm;
        public AccountController(IUserManager manager, IRatingManager ratingManager, IDishManager dishManager)
        {
            _userManager = manager;
            _ratingManager = ratingManager; 
            _dishManager = dishManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
/*        [Extension()]*/
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.getUser(model.Email, model.UserName);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    user = new User { Email = model.Email, Password = model.Password, UserName = model.UserName };
                    await _userManager.Add(user);

                    await Authenticate(user); // аутентификация
                    ViewBag.em = user.Email;
                    return RedirectToAction("Personal_account", "Account");
                }
                else if (user.Email.Equals(model.Email))
                {
                    ModelState.AddModelError("", "пользователь с таким email уже существует");
                } else if (user.UserName.Equals(model.UserName))
                {
                    ModelState.AddModelError("", "Пользователь с таким именем уже существует");
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.getUserWithRole(model.Email, model.Password);
                if (user != null)
                {
                    await Authenticate(user);// аутентификация
                    ViewBag.em = user.Email;

                    return RedirectToAction("Personal_account", "Account");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        public async Task<IActionResult> Personal_account()
        {
            ViewBag.em = HttpContext.User.Identity.Name;
            if (!HttpContext.User.Identity.IsAuthenticated) { RedirectToAction("Register", "Account"); }
            return View();
        }
        private async Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        //Выход из аккаунта(Удаляем куки)
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        #region forAdmin
        [HttpGet]
        public IActionResult CreateDish()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateDish(Dish dish)
        {
            var dishh = await _dishManager.getDish(dish.Dish_Id);
            if (dishh == null)
                _dishManager.Create(dish);
            return View();
        }

      
        public async Task<IActionResult> Dishes()
        {
            rvm = new Dictionary<Dish, Rating>();
            var dishes = await _dishManager.GetAll();
            foreach (var dish in dishes)
            {
                rvm.Add(dish, await _ratingManager.GetDishRating(dish.Dish_Id));
            }
            ViewBag.rvm = rvm;
            return View();
        }
        public async Task<IActionResult> DeleteDish(int id)
        {
            await _dishManager.Delete(id);
            return RedirectToAction("Dishes");

        }
        public async Task<IActionResult> Users()
        {
            ViewBag.uvm = await _userManager.GetAll();
            return View(); 
        }
/*          return RedirectToAction("Users");*/
        public async Task<IActionResult> Delete(int id)
        {
            await _userManager.Delete(id);
            return RedirectToAction("Users");
        }
        #endregion

        #region forUser
        public async Task<IActionResult> cookedDishes()
        {
            rvm = new Dictionary<Dish, Rating>();
            var dishes = _cookedManager.GetAll(HttpContext.User.Identity.Name);
            foreach (var dish in dishes)
            {
                rvm.Add(dish, await _ratingManager.GetDishRating(dish.Dish_Id));
            }
            ViewBag.rvm = rvm;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCooked(int ratingId)
        {
            _cookedManager.Delete(ratingId, HttpContext.User.Identity.Name);
            return RedirectToAction("cookedDishes");
        }

        [HttpGet]
        public async Task<IActionResult> Settings()
        {
            var user = await _userManager.getUser(HttpContext.User.Identity.Name, "");
            ViewBag.UserName = user.UserName;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangeUserName(string name)
        {
            _userManager.ChangeNick(name, HttpContext.User.Identity.Name);
            
            return RedirectToAction("Settings");
        }
        #endregion
    }
}
