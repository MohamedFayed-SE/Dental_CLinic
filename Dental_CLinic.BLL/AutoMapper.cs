using AutoMapper;
using Dental_CLinic.BAl.Models;
using Dental_CLinic.BLL.ViewModels;
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
           
            
        }
    }
}
