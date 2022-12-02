using Dental_CLinic.BAl.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_CLinic.BLL.ViewModels
{
    public class CItyVM
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }

        public int CountryId { get; set; }
        public Country? Country { get; set; }
    }
}
