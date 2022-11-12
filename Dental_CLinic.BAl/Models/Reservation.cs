using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_CLinic.BAl.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public DateTime ReservationDate { get; set; }
        [Required]

        public Client Client { get; set; }

        

    }
}
