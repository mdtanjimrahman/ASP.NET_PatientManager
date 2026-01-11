using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.EF.Models
{
    public class Doctor
    {
        public int DoctorID { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string LastName { get; set; }

        [StringLength(100)]
        [Column(TypeName = "varchar")]
        public string Specialization { get; set; }

        [StringLength(15)]
        [Column(TypeName = "varchar")]
        public string ContactNumber { get; set; }

        [StringLength(100)]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }
    }
}
