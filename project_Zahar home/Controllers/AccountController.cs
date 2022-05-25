using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using project_Zahar_home.Logic.Users;
using project_Zahar_home.Models;
using project_Zahar_home.Storage.Entities;
using System.Runtime.CompilerServices;
using System.Security.Claims;


namespace project_Zahar_home.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserManager _manager;
        private static User _user;
        public int z = 0;
        public AccountController(IUserManager manager)
        {
            _manager = manager;
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
                var user = await _manager.getUser(model.Email);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    user = new User { Email = model.Email, Password = model.Password };
                    await _manager.Add(user);

                    await Authenticate(user); // аутентификация
                    _user = user;
                    z = 1;//пока нигде не используется

                    return RedirectToAction("Personal_account", "Account");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
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
                var user = await _manager.getUserWithRole(model.Email, model.Password);
                if (user != null)
                {
                    await Authenticate(user);// аутентификация
                    _user = user;
                    int z = 1;
                    return RedirectToAction("Personal_account", "Account");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        public IActionResult Personal_account()
        {
            ViewBag.User = _user;
            z = 0;
            if (_user == null) { RedirectToAction("Register", "Account"); } 
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
            _user = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
