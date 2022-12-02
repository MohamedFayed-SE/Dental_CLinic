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
    public class CityService:ICityService
    {
        private readonly ApplicationDbContxt _Context;
        private readonly IMapper _Mapper;
        public CityService(ApplicationDbContxt contxt, IMapper mapper)
        {
            _Context = contxt;
            _Mapper = mapper;
        }

        public ICollection<CItyVM> Get()
        {
            var cities = _Context.cities.ToList();
            var Result = _Mapper.Map < ICollection < CItyVM >> (cities);

            return Result;
        }

        public CItyVM GetById(int cityId)
        {
            throw new NotImplementedException();
        }

        public ICollection<CItyVM> getCitiesByCOountryID(int countryID)
        {
            var Data = _Context.cities.Where(c => c.CountryId == countryID);
               
            var Result = _Mapper.Map<ICollection<CItyVM>>(Data);
            return Result;
        }
    }
}
