using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DocApp1.Models
{
    public class Doctor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoctorID { get; set; }
        public string Name { get; set; }
        public long Contact { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Specialization { get; set; }
    }
}
