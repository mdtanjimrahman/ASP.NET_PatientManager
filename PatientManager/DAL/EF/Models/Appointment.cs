using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.EF.Models
{
    public class Appointment
    {
        public int AppointmentID { get; set; }

        public DateTime AppointmentDate { get; set; }

        [StringLength(200)]
        [Column(TypeName = "varchar")]
        public string Reason { get; set; }

        [StringLength(20)]
        [Column(TypeName = "varchar")]
        public string Status { get; set; }  // scheduled, completed, canceled

        [ForeignKey("Patient")]
        public int PatientID { get; set; }  
        public virtual Patient Patient { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }   

        public virtual Doctor Doctor { get; set; }
    }
}
