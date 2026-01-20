using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    internal class PaymentRepo : IPaymentFeature
    {
        PMContext db;

        public PaymentRepo(PMContext db)
        {
            this.db = db;
        }

        public bool MakePayment(int appointmentId, double amount)
        {
            var appointment = db.Appointments.FirstOrDefault(a => a.AppointmentID == appointmentId);

            if (appointment == null)
                return false;

            // create payment
            var payment = new Payment
            {
                AppointmentID = appointmentId,
                Amount = amount,
                PaymentDate = DateTime.Now
            };

            db.Payments.Add(payment);
            appointment.Status = "Completed";

            return db.SaveChanges() > 0;
        }
    }
}
