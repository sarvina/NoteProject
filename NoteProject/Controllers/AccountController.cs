namespace NoteProject.Controllers
{
  
    using Microsoft.AspNetCore.Mvc;
    using NoteProject.Service.Interfaces;

    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (_userService.ValidateUser(username, password))
            {
                // Успешный вход
                TempData["Message"] = "Вы успешно вошли!";
                return RedirectToAction("Index", "Note");
            }

            // Неверные данные
            ViewBag.ErrorMessage = "Неверное имя пользователя или пароль";

            return View();
        }
    }

}
