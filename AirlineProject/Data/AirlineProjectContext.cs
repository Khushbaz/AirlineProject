using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AirlineProject.Models;

namespace AirlineProject.Data
{
    public class AirlineProjectContext : DbContext
    {
        public AirlineProjectContext (DbContextOptions<AirlineProjectContext> options)
            : base(options)
        {
        }

        public DbSet<AirlineProject.Models.Airline> Airline { get; set; }

        public DbSet<AirlineProject.Models.StaffMember> StaffMember { get; set; }

        public DbSet<AirlineProject.Models.Traveller> Traveller { get; set; }

        public DbSet<AirlineProject.Models.TicketPrice> TicketPrice { get; set; }
    }
}
