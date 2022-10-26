using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewAgency.Areas.admin.DTOs;
using NewAgency.Models;

namespace NewAgency.Areas.admin.Controllers
{
    [Area(nameof(admin))]
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user == null)
            {
                ViewBag.UserNotFound = "Error. User was not found.";
                return View();
            }
            Microsoft.AspNetCore.Identity.SignInResult result =
                await _signInManager.PasswordSignInAsync(user, loginDTO.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            User newUser = new()
            {
                Email = registerDTO.Email,
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                UserName = registerDTO.UserName,

            };
            IdentityResult result = await _userManager.CreateAsync(newUser, registerDTO.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

    }
}
