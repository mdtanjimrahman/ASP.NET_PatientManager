using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.EF.Models
{
    public class Medication
    {
        public int MedicationID { get; set; }

        [StringLength(100)]
        [Column(TypeName = "varchar")]
        public string MedicationName { get; set; }

        [StringLength(20)]
        [Column(TypeName = "varchar")]
        public string Dosage { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string Duration { get; set; }

        [Required]
        [ForeignKey("Prescription")]
        public int PrescriptionID { get; set; }

        public virtual Prescription Prescription { get; set; }
    }
}
