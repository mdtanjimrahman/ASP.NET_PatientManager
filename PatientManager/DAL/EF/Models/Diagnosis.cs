using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.EF.Models
{
    public class Diagnosis
    {
        public int DiagnosisID { get; set; }

        public DateTime DiagnosisDate { get; set; }

        [StringLength(500)]
        [Column(TypeName = "varchar")]
        public string DiagnosisDetails { get; set; }

        [ForeignKey("Patient")]
        public int PatientID { get; set; }  
        public virtual Patient Patient { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
