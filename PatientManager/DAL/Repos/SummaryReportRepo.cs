using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    internal class SummaryReportRepo : ISummaryReport
    {
        PMContext db;

        public SummaryReportRepo(PMContext db)
        {
            this.db = db;
        }

        // total patient, total doctor, total appointment
        public object GetSystemSummary()
        {
            return new
            {
                TotalPatients = db.Patients.Count(),
                TotalDoctors = db.Doctors.Count(),
                TotalAppointments = db.Appointments.Count()
            };
        }

        // Status total of scheduled, cancelled and completed
        public List<object> GetAppointmentStatusSummary()
        {
            return db.Appointments
                     .GroupBy(a => a.Status)
                     .Select(g => new
                     {
                         Status = g.Key,
                         Total = g.Count()
                     }).ToList<object>();
        }
    }
}
