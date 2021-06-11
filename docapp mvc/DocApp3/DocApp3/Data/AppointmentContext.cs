using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DocApp3.Models;

namespace DocApp3.Data
{
    public class AppointmentContext : DbContext
    {
        public AppointmentContext (DbContextOptions<AppointmentContext> options)
            : base(options)
        {
        }

        public DbSet<DocApp3.Models.Appointment> Appointment { get; set; }
    }
}
