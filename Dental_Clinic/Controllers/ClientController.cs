using Dental_CLinic.BLL.Interfaces;
using Dental_CLinic.BLL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dental_Clinic.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly ICityService _cityService;
        private readonly IRegionService _regionService;

        public ClientController(IClientService clientService, ICityService cityService, IRegionService regionService)
        {
            _clientService = clientService;
            _cityService = cityService;
            _regionService= regionService;
        }

        [HttpPost]
        public JsonResult GetCityByCountryId(int countryId)
        {
            var Result = _cityService.getCitiesByCOountryID(countryId);

            return Json(Result);
        }
        public JsonResult GetRegionsByCountryId(int cityId)
        {
            var Result = _regionService.getRegionsByCityId(cityId);
            return Json(Result);
        }
        [Authorize(Roles ="null")]
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
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

                //create folder if not exist
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                FileInfo fileInfo = new FileInfo(client.Photo.FileName);
                string fileName = client.Photo.FileName + fileInfo.Extension;

                string fileNameWithPath = Path.Combine(path, fileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    client.Photo.CopyTo(stream);
                }
                client.ClientPhoto = fileName;

                _clientService.Add(client);
                return RedirectToAction("Index");

            }
            






           

            return RedirectToAction("Index");
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

