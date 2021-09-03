using ElectronicDevices.EF;
using ElectronicDevices.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ElectronicDevices.Controllers
{
    public class AccountController : Controller
    {
        // класс UserManager содержит все API, необходимые для управления пользователем в базе данных
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

        }
        public IActionResult Login(string url) // string url - для перенаправления пользователя на определенный URL-адрес после того, как он уже был залогинен 
        {
            LoginViewModel vm = new LoginViewModel()
            {
                ReturnUrl = url
            };
            return View(vm);
        }

        

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await this.userManager.FindByNameAsync(vm.UserName);
                if (user != null)
                {
                    var res = await this.signInManager.PasswordSignInAsync(user, vm.Password, false, false);
                    if (res.Succeeded)
                    {
                        if (string.IsNullOrEmpty(vm.ReturnUrl))
                            return RedirectToAction("Index", "Home");
                        return Redirect(vm.ReturnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Неправильный логин и (или) пароль");
                    }
                }
                else
                {
                    ModelState.AddModelError("Password", "Не нейдено соответствующего логина/пароля");
                }
            }
            return View(vm);
        }

        [Authorize]
        public IActionResult Profile()
        {
            ViewBag.Message = "";
            UserProfileViewModel vm = new UserProfileViewModel
            {
                UserName = User.Identity.Name,
                Email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value
            };
            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileViewModel vm)
        {
            ViewBag.Message = "Данные сохранены";
            IdentityUser user = await this.userManager.FindByNameAsync(vm.UserName);

            if (user != null) 
            {
                user.Email = vm.Email;
                await this.userManager.UpdateAsync(user);
            }

            return View(vm);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser { UserName = vm.UserName, Email = vm.Email };

                var res = await this.userManager.CreateAsync(user, vm.Password); 
                if (res.Succeeded)
                    return RedirectToAction("Index", "Home");
                else
                {
                    foreach (IdentityError error in res.Errors)
                    {
                        ModelState.AddModelError("Password", error.Description);
                    }
                }
            }
            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
