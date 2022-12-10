using Dental_CLinic.BAl.Models;
using Dental_CLinic.BLL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Security.AccessControl;

namespace Dental_Clinic.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUserExtend> _userManager;
        private readonly SignInManager<IdentityUserExtend> _signInManager;
       


        public AccountController(UserManager<IdentityUserExtend> userManager, SignInManager<IdentityUserExtend> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Registration()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationVM model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var user = new IdentityUserExtend()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        IsAgree = model.IsAgree,
                        UserName = model.Email,

                    };
                    var result= await _userManager.CreateAsync(user,model.Password);
                    if(result.Succeeded)
                        return RedirectToAction("LogIn");
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                        return View(model);
                    }
                    

                }

            }catch(Exception )
            {

                return View(model);
            }

            return View();
        }
        public IActionResult LogIn()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LgoInVM input)
        {
            var user = await _userManager.FindByEmailAsync(input.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Enter  A valid Email");
                return View(input);
            }
            else
            {
                var Pssword = input.Password;
                var isCorrect = await _userManager.CheckPasswordAsync(user, Pssword);
                if (isCorrect)
                    return RedirectToAction("Index", "Home");
                else
                {
                    ModelState.AddModelError("", "InCoreect Password");
                    return View(input);
                }
                   


            }
            
            
           

        }
        public IActionResult ResetPassword()
        {

            return View();
        }
    }
}
