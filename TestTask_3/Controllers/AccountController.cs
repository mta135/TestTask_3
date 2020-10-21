using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerSalesStore.Domain.Abstract;
using FlowerSalesStore.Domain.Entities;
using FlowerSalesStore.Domain.ViewModels;
using FlowerSaleStore.WebUI.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FlowerSaleStore.WebUI.Controllers
{
    //[Authorize]
    public class AccountController : Controller
    {
        //private UserManager<IdentityUser> userManager;
        //private SignInManager<IdentityUser> signInManager;

         private readonly IUser repository;

        public AccountController(/*UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signInMgr*/  IUser repository)
        {
            //userManager = userMgr;
            //signInManager = signInMgr;
            this.repository = repository;
        }

        [HttpGet]
        //[AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            //return View(new UserViewModel
            //{
            //    ReturnUrl = returnUrl
            //});

            return View(new User
            {
                ReturnUrl = returnUrl
            });

            //User userModel = new User();
            //return View(userModel);

        }

        [HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public IActionResult Login(User user)
        {
            User user1 = repository.FindUserByLoginAndPasswword(user.Login, user.Password);
            if(user1 != null)
            {
                HttpContext.Session.SetComplexData("User", user1);
                return Redirect("/Product/List");
            }  
            else
            {
                TempData["message"] = "You arent registred. Please register !";
                //repository.InsertUser(user);
                // return Redirect("/Product/List");
                return RedirectToAction(nameof(Register));
            }


            //return Redirect(User?.ReturnUrl ?? "/Admin/Index");
            //if (ModelState.IsValid)
            //{
            //IdentityUser user = await userManager.FindByNameAsync(loginModel.Name);
            //if (user != null)
            //{
            //    await signInManager.SignOutAsync();
            //    if ((await signInManager.PasswordSignInAsync(user,
            //    loginModel.Password, false, false)).Succeeded)
            //    {
            //        return Redirect(loginModel?.ReturnUrl ?? "/Admin/Index");
            //    }
            //}
            //}
            // ModelState.AddModelError("", "Invalid name or password");
            //return View(user);
        }

        public RedirectResult Logout(string returnUrl = "/")
        {
            //await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new Register());
        }

        [HttpPost]
        public IActionResult Register(Register register)
        {
            if(ModelState.IsValid)
            {
                User user = new User
                {
                    NAME = register.Name,
                    Login = register.Login,
                    Password = register.Password,
                    Email = register.Email
                };
                repository.InsertUser(user);
                return Redirect("/Product/List");
            }
            return View(register);
        }
    }
}
