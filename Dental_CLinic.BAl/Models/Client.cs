using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public string ClientPhoto { get; set; }
        [NotMapped]

        public IFormFile Photo { get; set; }

        public int RegionId  { get; set; }

        public Region Region { get; set; }
        
    }
}
