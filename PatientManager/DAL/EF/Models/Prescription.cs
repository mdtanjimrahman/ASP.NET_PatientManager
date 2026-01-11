using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.EF.Models
{
    public class Prescription
    {
        public int PrescriptionID { get; set; }

        [ForeignKey("Patient")]
        public int PatientID { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }

        public DateTime PrescriptionDate { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual ICollection<Medication> Medications { get; set; }

        public Prescription()
        {
            Medications = new List<Medication>();
        }
    }
}
