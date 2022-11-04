
using Dental_CLinic.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dental_Clinic.Controllers
{
    public class HomeController : Controller
    {
        
        

        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }

        

      
        
    }
}