using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DocApp1.Models
{
    public class Appointment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime Date { get; set; }
        public string HealthIssue { get; set; }
        public string Prescription { get; set; }
        public string Status { get; set; }
        public string Review { get; set; }
    }
}
