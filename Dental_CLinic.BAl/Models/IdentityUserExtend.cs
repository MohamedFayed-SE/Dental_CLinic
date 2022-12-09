using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_CLinic.BAl.Models
{
    public class IdentityUserExtend: IdentityUser
    {
        public bool IsAgree { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
    }
}
