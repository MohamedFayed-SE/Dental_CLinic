using Dental_CLinic.BAl.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_CLinic.BAl
{
    public class ApplicationDbContxt:IdentityDbContext<IdentityUserExtend>
    {
        public ApplicationDbContxt(DbContextOptions<ApplicationDbContxt> options):base(options)
        {

        }


        public DbSet<Client> clients { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<City> cities { get; set; }

        public DbSet<Region> regions { get; set; }

    }
}
