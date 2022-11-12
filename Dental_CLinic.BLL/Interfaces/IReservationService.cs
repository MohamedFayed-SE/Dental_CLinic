using Dental_CLinic.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_CLinic.BLL.Interfaces
{
    public interface IReservationService
    {
        public IEnumerable<ReservationVM> Get();
        public Task<ReservationVM> GetById(int id);
        public void Add(ReservationVM ReservationVM);
        public void Update(ReservationVM ReservationVM);
        public void Delete(int id);
    }
}
