using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using BarberShop.Models;
using BarberShop.ViewModel; //need login view model to be passed 

namespace BarberShop.Controllers
{
    public class AccountController : Controller
    {
        //this is a class given by identity to do everything with signing in
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;
        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        //[HttpGet("/Account/Login")]
        public IActionResult Login()
        {
            if(this.User.Identity.IsAuthenticated) //if user is authenticated then send them to user pages 
            { //to home page or any page
               return RedirectToAction("Index","Home"); 
            }
            return View(); //if not return to view to try and login again until authenticated 
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginmodel)
        {
           if (ModelState.IsValid)
           {
               var result = await _signInManager.PasswordSignInAsync(loginmodel.UserName, loginmodel.Password, loginmodel.RememberMe, false);
               if (result.Succeeded)
               {
                   return RedirectToAction("Index", "Home"); 
                }
            }
            ModelState.AddModelError("", "Failed to login");
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home"); //once logged out the user will be redirected to the Home page 
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                BarberShop.Models.User newuser = new User
                {//here we are inserted data that we entered
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    UserName = registerViewModel.UserName,
                    PhoneNumber = registerViewModel.PhoneNumber.ToString(),
                    Email = registerViewModel.Email
                };
                var result = await _userManager.CreateAsync(newuser, registerViewModel.Password);
                //if (result.Succeeded) //if it succeeded then go to the Login page
                //{
                //    var addeduser = await _userManager.FindByNameAsync(newuser.UserName);
                //    if (newuser.UserName == "Admin")//simple here to add users to a certain role 
                //    {
                //        await _userManager.AddToRoleAsync(addeduser, "Admin");//adding this user to the Admin role 
                //        await _userManager.AddToRoleAsync(addeduser, "Employee"); //you can add many roles to one user
                //    }
                //    else
                //    {
                //        await _userManager.AddToRoleAsync(addeduser, "Employee");
                //    }
                //    return RedirectToAction("Login", "Account");
                //}
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return RedirectToAction("Login","Account");
                

            }

            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
