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
                    }
                }
            }
            return View(registerViewModel);
        }        
    }
}