using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.EF.Models
{
    public class Patient
    {
        public int PatientID { get; set; }


        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string LastName { get; set; }

        public DateTime DOB { get; set; }

        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string Gender { get; set; }

        [StringLength(15)]
        [Column(TypeName = "varchar")]
        public string ContactNumber { get; set; }

        [StringLength(80)]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }

        [StringLength(255)]
        [Column(TypeName = "varchar")]
        public string Address { get; set; }

        public DateTime DateJoined { get; set; }
    }
}
