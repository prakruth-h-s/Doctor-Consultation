using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DocApp3.Models
{
    public class Appointment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string AppointmentID { get; set; }
        public string PatientID { get; set; }
        public string DoctorID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string HealthIssue { get; set; }
        public string PrescriptionGiven { get; set; }
        public int Rating { get; set; }
        public string ReviewComment { get; set; }

    }
}
