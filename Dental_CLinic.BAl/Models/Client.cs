using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_CLinic.BAl.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required,MaxLength(50)]
        public string Name { get; set; }
        [Required,MaxLength(15)]
        public int Phone { get; set; }
        [Required,MaxLength(80)]
        public string Address { get; set; }

        public ICollection<Reservation> reservations;
    }
}
