using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DocApp3.Models
{
    public class Patient
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string PatientID { get; set; }
        public string Name { get; set; }
        public long Contact { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
