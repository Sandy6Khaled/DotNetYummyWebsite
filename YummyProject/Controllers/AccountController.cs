using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YummyProject.Models;
using YummyProject.Repositories.Classes;
using YummyProject.Repositories.Interfaces;
using YummyProject.ViewModels;

namespace YummyProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IUserRepo userRepo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepo = userRepo;
        }

        public IUserRepo _userRepo { get; }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]

        public IActionResult Register() // normal register
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            //AppUser user = null;
            if (ModelState.IsValid)
            {
                if (_userRepo.EmailExist(model.Email))
                {
                    ModelState.AddModelError("Email", "Email already registered");
                    return View(model);
                }
                if (_userRepo.UsernameExist(model.Username))
                {
                    ModelState.AddModelError("Username", "Username is taken");
                    return View(model);
                }
                var user = new AppUser
                {
                    UserName = model.Username,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = "+20 0",
                    EmailConfirmed = true
                };
                await _userManager.CreateAsync(user, model.Password);
                return RedirectToAction("Login");
            }
            return View(model);
        }
        [HttpGet]

        public IActionResult Login(string returnUrl = null) // Reviewed
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost] // Reviewed
        public async Task<IActionResult> Login(LoginUserViewModel UserLoginVM) //normal login
        {
            if (ModelState.IsValid)
            {
                var userExist = await _userManager.Users.SingleOrDefaultAsync(x => x.Email == UserLoginVM.Email);

                if (userExist != null)
                {
                    bool passwordCorrect = await _userManager.CheckPasswordAsync(userExist, UserLoginVM.Password);

                    if (passwordCorrect)
                    {
                        await _signInManager.SignInAsync(userExist, UserLoginVM.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("LoginError", "Wrong Email Or Password");
            return View(UserLoginVM);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync(); // if normal login
            return RedirectToAction("Login", "Account");
        }
    }
}
