using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    internal class PrescriptionRepo : Repository<Prescription>, IPrescriptionFeature
    {
        public PrescriptionRepo(PMContext db) : base(db) { }

        public List<Prescription> GetByPatient(int patientId)
        {
            var data = (from p in db.Prescriptions
                        where p.PatientID == patientId
                        select p).ToList();

            return data;
        }

        public List<Prescription> GetByDoctor(int doctorId)
        {
            var data = (from p in db.Prescriptions
                        where p.DoctorID == doctorId
                        select p).ToList();

            return data;
        }
    }
}
