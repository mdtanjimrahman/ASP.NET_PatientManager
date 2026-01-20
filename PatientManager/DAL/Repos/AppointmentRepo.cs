using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    internal class AppointmentRepo : Repository<Appointment>, IAppointmentFeature
    {
        public AppointmentRepo(PMContext db) : base(db) { }

        // CRUD available from base Repo


        // get appointments of doctor by id
        public List<Appointment> GetByDoctor(int doctorId)
        {
            var data = (from a in db.Appointments
                        where a.DoctorID == doctorId
                        select a).ToList();

            return data;
        }

        public List<Appointment> GetByPatient(int patientId)
        {
            var data = (from a in db.Appointments
                        where a.PatientID == patientId
                        select a).ToList();

            return data;
        }

        public bool ChangeStatus(int appointmentId, string status)
        {
            var ap = db.Appointments.FirstOrDefault(a => a.AppointmentID == appointmentId);

            if (ap == null) 
                return false;

            ap.Status = status;
            db.SaveChanges();
            return true;
        }

        public Appointment GetWithRelations(int appointmentId)
        {
            return db.Appointments
                     .Include(a => a.Patient)
                     .Include(a => a.Doctor)
                     .FirstOrDefault(a => a.AppointmentID == appointmentId);
        }
    }
}
