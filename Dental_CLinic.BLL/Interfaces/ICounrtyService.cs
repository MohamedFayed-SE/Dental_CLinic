using Dental_CLinic.BAl.Models;
using Dental_CLinic.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_CLinic.BLL.Interfaces
{
    public interface ICounrtyService
    {
        public ICollection<CountryVM> Get();

        
        public CountryVM GetById(int cityId);
    }
}
