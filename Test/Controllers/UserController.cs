using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Model.Model;
using System.Security.Claims;

namespace Test.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Readers()
        {
            var users = _userService.GetAllUsers();
            return View(users);
        }
        public IActionResult Index()
        {
            var users = _userService.GetAllUsers();
            return View(users);
        }
        public IActionResult RegisterUser()
        {
            return View();
        }
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Registration(User user)
        {
            try
            {
                    _userService.CreateUser(user);
                    return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewData["ErrorMessage"] = "Произошла ошибка при регистрации пользователя.";
                return View("Error");
            }
        }
        [HttpPost("login")]
        public IActionResult Login(string selectedLastName)
        {
            var user = _userService.GetUserByLastName(selectedLastName);

            if (user != null)
            {
                var claims = new List<Claim>
                 {
                     new Claim(ClaimTypes.Name, user.LastName),
                      new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                 };

                var identity = new ClaimsIdentity(claims, "Cookies");

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                return RedirectToAction("AvailableBook", "Book");
            }
            else
            {
                throw new Exception("Пользователь не найден в систему");
            }
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}

