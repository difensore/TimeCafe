using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TimeCafe.DAL.Models.ViewModels;
using TimeCafe.Models;
using TimeCafe.Services.Interfaces;

namespace TimeCafe.Controllers
{
    public class UserController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IIdentityProvider identityProvider;
        public UserController(SignInManager<IdentityUser> signInManager, IIdentityProvider identityProvider)
        {
            this.signInManager = signInManager;
            this.identityProvider = identityProvider;
        }

        [HttpGet]
        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegisterPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var dictionary = identityProvider.CreateUserAsync(registerViewModel).Result;

                if (dictionary.ElementAt(0).Key.Succeeded)
                {
                    await signInManager.SignInAsync(dictionary.ElementAt(0).Value, false);
                    return View("~/Views/Home/Index.cshtml");
                }
                else
                {
                    foreach (var error in dictionary.ElementAt(0).Key.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        throw new Exception(error.Description);
                    }
                }
            }

            return View(registerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Wrong Login or Password");
                }
            }

            return View("LoginPage", model);
        }

        [Authorize]
        public async Task<IActionResult> LogOutAsync()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}