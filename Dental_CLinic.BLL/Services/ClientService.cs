using AutoMapper;
using Dental_CLinic.BAl;
using Dental_CLinic.BAl.Models;
using Dental_CLinic.BLL.Interfaces;
using Dental_CLinic.BLL.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_CLinic.BLL.Services
{
    public class ClientService : IClientService
    {
        private readonly ApplicationDbContxt _Context;
        private readonly IMapper _Mapper;
        public ClientService(ApplicationDbContxt applicationDbContxt,IMapper mapper)
        {
            _Context = applicationDbContxt;
            _Mapper = mapper;   
        }
        public void Add(ClientVM clientVM)
        {
            var Result = _Mapper.Map<Client>(clientVM);
            _Context.clients.Add(Result);
            _Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var client=_Context.clients.FirstOrDefault(x => x.Id == id);
            _Context.clients.Remove(client);
            _Context.SaveChanges();
        }
        

        public IEnumerable<ClientVM> Get()
        {
            var Clients = _Context.clients;
            var Result = _Mapper.Map<IEnumerable<ClientVM>>(Clients);

            return Result;  
        }

        public async Task<ClientVM> GetById(int id)
        {
            var client= await  _Context.clients.FirstOrDefaultAsync(x => x.Id == id);
            var Result = _Mapper.Map<ClientVM>(client);
            return Result;
        }

        public void Update(ClientVM clientVM)
        {
            var client= _Context.clients.FirstOrDefault(c=>c.Id==clientVM.Id);
            if(client != null)
            {
                client.Name = clientVM.Name;
                client.Phone = clientVM.Phone;
                client.Address = clientVM.Address;
                _Context.clients.Update(client);
                _Context.SaveChanges();
            }
           
        }
    }
}
