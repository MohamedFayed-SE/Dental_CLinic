using Dental_CLinic.BAl.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_CLinic.BLL.ViewModels
{
    public class ReservationVM
    {
        public int Id { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public DateTime ReservationDate { get; set; }
        [Required]
        public int ClientId { get; set; }
        public Client?  Client { get; set; }
    }
}
