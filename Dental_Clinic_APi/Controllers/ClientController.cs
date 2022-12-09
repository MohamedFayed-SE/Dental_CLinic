using AutoMapper;
using Dental_CLinic.BLL.Helper;
using Dental_CLinic.BLL.Interfaces;
using Dental_CLinic.BLL.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Dental_CLinic.BLL.ViewModels.API;
using Microsoft.VisualBasic;

namespace Dental_Clinic_APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var clients = _clientService.Get();
                var data = _mapper.Map<ICollection<ClientAPIVM>>(clients);
                
                var Result = new APiResponse<ICollection<ClientAPIVM>>()
                {
                    Code = 200,
                    Message="Succuess",
                    Status= "OK",
                    Result = data
                };

                return Ok(Result);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public  async Task<IActionResult> GetById(int id)
        {
            try
            {
                
                var Clinet =  await _clientService.GetById(id);
                if(Clinet==null)
                {
                    var Result = new APiResponse<string>()
                    {
                        Code = 400,
                        Message = "Failed",
                        Status = "Not Found ",
                        Result = "Cannot Find Client With Id="+id
                    };
                    return Ok(Result);
                }  
                else
                {
                    var data = _mapper.Map<ClientAPIVM>(Clinet);

                    var Result = new APiResponse<ClientAPIVM>()
                    {
                        Code = 200,
                        Message = "Succuess",
                        Status = "OK",
                        Result = data
                    };

                    return Ok(Result);
                }
                            
               
            }
            catch (Exception ex)
            {
                var Result = new APiResponse<string>()
                {
                    Code = 404,
                    Message = "Failed",
                    Status = "Bad Request",
                    Result = ex.Message
                };

                return BadRequest(Result);
            }

        }
    }
}
