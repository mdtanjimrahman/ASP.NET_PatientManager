using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    internal class AppointmentRepo
        : Repository<Appointment>, IAppointmentFeature
    {
        public AppointmentRepo(PMContext db) : base(db)
        {
        }

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
            var appointment = (from a in db.Appointments
                               where a.AppointmentID == appointmentId
                               select a).FirstOrDefault();

            if (appointment == null) return false;

            appointment.Status = status;
            return db.SaveChanges() > 0;
        }
    }
}
