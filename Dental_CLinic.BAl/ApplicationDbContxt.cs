using Dental_CLinic.BAl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_CLinic.BAl
{
    public class ApplicationDbContxt:DbContext
    {
        public ApplicationDbContxt(DbContextOptions<ApplicationDbContxt> options):base(options)
        {

        }


        public DbSet<Client> clients { get; set; }

    }
}
