using AutoMapper;
using Dental_CLinic.BAl.Models;
using Dental_CLinic.BLL.ViewModels;
using Dental_CLinic.BLL.ViewModels.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dental_CLinic.BLL
{
    internal class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<ClientVM, Client>().ReverseMap();
            CreateMap<ReservationVM, Reservation>().ReverseMap();

            CreateMap<CountryVM, Country>().ReverseMap();
            CreateMap<CItyVM, City>().ReverseMap();
            CreateMap<RegionVM, Region>().ReverseMap();
            CreateMap<ClientVM, ClientAPIVM>()
                .ForMember(dist => dist.RegionName, src => src.MapFrom(c => c.Region.Name))
                .ForMember(dist => dist.countryName, src => src.MapFrom(c => c.Region.City.Name))
                .ForMember(dist => dist.countryName, src => src.MapFrom(c => c.Region.City.Country.Name))
                .ForMember(dist => dist.ClientName, src => src.MapFrom(c => c.Name));

            




        }
    }
}
