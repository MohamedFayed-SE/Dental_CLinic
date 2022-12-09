using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_CLinic.BLL.ViewModels
{
    public class LogInVM
    {
        public  string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
