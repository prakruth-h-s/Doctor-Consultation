using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DocApp1.Models;

namespace DocApp1.Data
{
    public class DoctorContext : DbContext
    {
        public DoctorContext (DbContextOptions<DoctorContext> options)
            : base(options)
        {
        }

        public DbSet<DocApp1.Models.Doctor> Doctor { get; set; }
    }
}
