using AutoMapper;
using Dental_CLinic.BAl;
using Dental_CLinic.BLL.Interfaces;
using Dental_CLinic.BLL.ViewModels;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_CLinic.BLL.Services
{
    public class CountryService : ICounrtyService
    {

        private readonly ApplicationDbContxt _Context;
        private readonly IMapper _Mapper;
        public CountryService(ApplicationDbContxt contxt,IMapper mapper)
        {
            _Context = contxt;
            _Mapper = mapper;
        }
        public ICollection<CountryVM> Get()
        {
            var Result=_Mapper.Map<ICollection<CountryVM>>(_Context.countries);
            return Result;
        }

        public CountryVM GetById(int cityId)
        {
            var data=_Context.countries.FirstOrDefault(c=>c.Id==cityId);
            var Result = _Mapper.Map<CountryVM>(data);
            return Result;

        }
    }
}
