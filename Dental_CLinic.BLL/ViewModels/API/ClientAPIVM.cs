using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_CLinic.BLL.ViewModels.API
{
    public class ClientAPIVM
    {
        public int id { get; set; }
        public int phone { get; set; }
        public string RegionName { get; set; }
        public string ClientName { get; set; }
        public string Address { get; set; }
        public string countryName { get; set; }

        
    }
}
