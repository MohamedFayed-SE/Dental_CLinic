using Dental_CLinic.BAl.Models;
using Dental_CLinic.BLL.Interfaces;
using Dental_CLinic.BLL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Security.AccessControl;

namespace Dental_Clinic.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _IReservationService;
        private readonly IClientService _ClientService;



        public ReservationController(IReservationService IreservationService,IClientService clientService)
        {
            _IReservationService= IreservationService;
            _ClientService= clientService;
        }
        public IActionResult Index()
        {
            var Result = _IReservationService.Get();
            return View(Result);
        }

        public IActionResult Add()
        {
            var Clients = _ClientService.Get();
            var ClientsList = new SelectList(Clients, "Id", "Name");
            ViewBag.ClientsList = ClientsList;
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
            else
            {
                var Clients = _ClientService.Get();
                var ClientsList = new SelectList(Clients, "Id", "Name");
                ViewBag.ClientsList = ClientsList;
            }
                  
            return View();
        }



    }
}
