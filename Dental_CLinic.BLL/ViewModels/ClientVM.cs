using Dental_CLinic.BAl.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_CLinic.BLL.ViewModels
{
    public class ClientVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name Is Required"), MaxLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage ="Phone is Required")]
        public int Phone { get; set; }
        [Required(ErrorMessage ="Addres is Required"), MaxLength(80)]
        public string Address { get; set; }

        public int RegionId { get; set; }

        public Region? Region { get; set; }
    }
}
