using Dental_CLinic.BLL.Interfaces;
using Dental_CLinic.BLL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Security.AccessControl;

namespace Dental_Clinic.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _IReservationService;



        public ReservationController(IReservationService IreservationService)
        {
            _IReservationService= IreservationService;
        }
        public IActionResult Index()
        {
            var Result = _IReservationService.Get();
            return View(Result);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(ReservationVM reservation)
        {
            if(ModelState.IsValid)
            {
                _IReservationService.Add(reservation);
                return RedirectToAction("Index");
            }
            return View();
        }



    }
}
