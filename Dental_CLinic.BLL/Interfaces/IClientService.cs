using Dental_CLinic.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_CLinic.BLL.Interfaces
{
    public interface IClientService
    {
        public IEnumerable<ClientVM> Get();
        public  Task< ClientVM> GetById(int id);
        public void Add(ClientVM clientVM);
        public void Update(ClientVM clientVM);  
        public void Delete(int id);

        

        
    }
}
