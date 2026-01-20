using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int AppointmentID { get; set; }
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public virtual Appointment Appointment { get; set; }
    }
}
