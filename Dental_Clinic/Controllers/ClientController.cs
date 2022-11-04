using Dental_CLinic.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dental_Clinic.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        public IActionResult Index()
        {
            var Result = _clientService.Get();
            return View(Result);
        }
    }
}
