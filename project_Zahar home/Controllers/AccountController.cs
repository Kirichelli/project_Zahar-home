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
        IWebHostEnvironment _appEnvironment;
        private readonly IUserManager _userManager;
        private readonly IDishManager _dishManager;
        private readonly IRatingManager _ratingManager;
        private readonly ICookedManagercs _cookedManager;
        private static Dictionary<Dish, Rating> rvm;
        public AccountController(IUserManager manager, IRatingManager ratingManager, IDishManager dishManager, ICookedManagercs cookedManager)
        {
            _userManager = manager;
            _ratingManager = ratingManager; 
            _dishManager = dishManager;
            _cookedManager = cookedManager;


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
                var user = _userManager.getUser(model.Email, model.UserName);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    user = new User { Email = model.Email, Password = model.Password, UserName = model.UserName };
                    _userManager.Add(user);

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
            return View();
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
                var user = _userManager.getUserWithRole(model.Email, model.Password);
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
        public IActionResult Personal_account()
        {
            ViewBag.pvm = _userManager.getUser(HttpContext.User.Identity.Name,"");
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
        public ActionResult CreateDish(Dish dish)
        {
            var dishh = _dishManager.getDish(dish.Dish_Id);
            if (dishh == null)
                _dishManager.Create(dish);
            return View();
        }

      
        public IActionResult Dishes()
        {
            ViewBag.name = HttpContext.User.Identity.Name;
            rvm = new Dictionary<Dish, Rating>();
            var dishes = _dishManager.GetAll();
            foreach (var dish in dishes)
            {
                rvm.Add(dish, _ratingManager.GetDishRating(dish.Dish_Id));
            }
            ViewBag.rvm = rvm;
            return View();
        }
        public IActionResult DeleteDish(int id)
        {
            _dishManager.Delete(id);
            return RedirectToAction("Dishes");

        }
        public IActionResult Users()
        {
            ViewBag.name = HttpContext.User.Identity.Name;
            ViewBag.uvm = _userManager.GetAll();
            return View(); 
        }
/*          return RedirectToAction("Users");*/
        public IActionResult Delete(int id)
        {
            _userManager.Delete(id);
            return RedirectToAction("Users");
        }
        #endregion

        #region forUser
        public IActionResult СookedDishes()
        {
            rvm = new Dictionary<Dish, Rating>();
            var dishes = _cookedManager.GetAll(HttpContext.User.Identity.Name);
            foreach (var dish in dishes)
            {
                rvm.TryAdd(dish, _ratingManager.GetDishRating(dish.Dish_Id));
            }
            ViewBag.rvm = rvm;
            return View();
        }

        //[ValidateAntiForgeryToken]
        public ActionResult DeleteCooked(int id)
        {
            _cookedManager.Delete(id, HttpContext.User.Identity.Name);
            return RedirectToAction("СookedDishes");
        }

        [HttpGet]
        public IActionResult Settings()
        {
            var user = _userManager.getUser(HttpContext.User.Identity.Name, "");
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

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = "/img/content/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot


                _userManager.ChangePhoto(path, uploadedFile.FileName, HttpContext.User.Identity.Name);


                /*FileMod file = new FileModel { Name = uploadedFile.FileName, Path = path };
                Files.Add(file);
                SaveChanges();*/
            }

            return RedirectToAction("Personal_account");
        }

            #endregion
        }
}
