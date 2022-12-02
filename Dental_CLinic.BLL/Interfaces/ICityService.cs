using Dental_CLinic.BAl.Models;
using Dental_CLinic.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_CLinic.BLL.Interfaces
{
    public interface ICityService
    {
        public ICollection<CItyVM> Get();

        public ICollection<CItyVM> getCitiesByCOountryID(int countryID);
        public CItyVM GetById(int cityId);
    }
}
