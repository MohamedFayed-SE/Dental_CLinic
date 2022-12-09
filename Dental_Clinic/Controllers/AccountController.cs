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


        public AccountController(UserManager<IdentityUserExtend> userManager)
        {
            _userManager = userManager;
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
        public IActionResult ResetPassword()
        {

            return View();
        }
    }
}
