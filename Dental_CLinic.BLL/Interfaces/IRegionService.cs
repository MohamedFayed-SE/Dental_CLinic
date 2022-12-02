using Dental_CLinic.BAl.Models;
using Dental_CLinic.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_CLinic.BLL.Interfaces
{
    public interface IRegionService
    {
        public ICollection<RegionVM> Get();

        public ICollection<RegionVM> getRegionsByCityId(int cityId);
        public RegionVM GetById(int cityId);
    }
}
