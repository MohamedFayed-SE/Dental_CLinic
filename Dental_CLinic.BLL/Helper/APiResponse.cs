using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_CLinic.BLL.Helper
{
    public class APiResponse <Type>
    {
        public int Code { get; set; }   
        public string Message { get; set; } 
        public string Status { get; set; }
        public Type Result { get; set; }
    }
}
