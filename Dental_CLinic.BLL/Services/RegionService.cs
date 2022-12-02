using AutoMapper;
using Dental_CLinic.BAl;
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
    public class RegionService : IRegionService
    {
        private readonly ApplicationDbContxt _Context;
        private readonly IMapper _Mapper;
        public RegionService(ApplicationDbContxt contxt, IMapper mapper)
        {
            _Context = contxt;
            _Mapper = mapper;
        }
        public ICollection<RegionVM> Get()
        {
            var regions = _Context.regions;
            var Result = _Mapper.Map<ICollection<RegionVM>>(regions);
            return Result;
        }

        public RegionVM GetById(int cityId)
        {
            throw new NotImplementedException();
        }

        public ICollection<RegionVM> getRegionsByCityId(int cityId)
        {
            var data = _Context.regions.Where(r => r.CityId == cityId);
               
            var Result = _Mapper.Map<ICollection<RegionVM>>(data);

            return Result;

        }
    }
}
