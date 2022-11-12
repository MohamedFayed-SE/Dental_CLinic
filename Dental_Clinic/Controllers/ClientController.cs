using Dental_CLinic.BLL.Interfaces;
using Dental_CLinic.BLL.ViewModels;
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
        public IActionResult Add()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Add(ClientVM client )
        {
            if (ModelState.IsValid)
            {
                _clientService.Add(client);
                return RedirectToAction("Index");

            }
         
           

            


            return View();

           // return RedirectToAction("Index");
        }

        public  async Task<IActionResult> Edit(int id)
        {


            var Client =  await  _clientService.GetById(id);

            return View(Client);

            // return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(ClientVM client)
        {


            if (ModelState.IsValid)
            {
                _clientService.Update(client);
                return RedirectToAction("Index");

            }






            return View();

            // return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
           _clientService.Delete(id); 

            return View("Index");
        }

    }
}

