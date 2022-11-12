using AutoMapper;
using Dental_CLinic.BAl;
using Dental_CLinic.BAl.Models;
using Dental_CLinic.BLL.Interfaces;
using Dental_CLinic.BLL.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Dental_CLinic.BLL.Services
{
    public class ReservationService : IReservationService
    {
        private readonly ApplicationDbContxt _Context;
        private readonly IMapper _Mapper;
        public ReservationService(ApplicationDbContxt contex,IMapper mapper)
        {
            _Context= contex;
            _Mapper= mapper;
        }
        public void Add(ReservationVM ReservationVM)
        {
            var Result = _Mapper.Map<Reservation>(ReservationVM);

            _Context.Reservations.Add(Result);
            _Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var result = _Context.Reservations.FirstOrDefault(R => R.Id == id);
            _Context.Reservations.Remove(result);
            _Context.SaveChanges();
        }

        public IEnumerable<ReservationVM> Get()
        {
            var reserves = _Context.Reservations;
            var Result = _Mapper.Map<ICollection<ReservationVM>>(reserves);

            return Result;
        }

        public async Task<ReservationVM> GetById(int id)
        {
            var reserve =  await  _Context.Reservations.FirstOrDefaultAsync(R => R.Id == id);
           var result = _Mapper.Map<ReservationVM>(reserve);

            return result;
        }

        public void Update(ReservationVM ReservationVM)
        {
            var reserve =  _Context.Reservations.First(R => R.Id == ReservationVM.Id);

            reserve.Price = ReservationVM.Price;
            reserve.ReservationDate = ReservationVM.ReservationDate;
            reserve.Client.Id = ReservationVM.ClientId;

            _Context.SaveChanges();


        }
    }
}
