using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    internal class DiagnosisRepo : Repository<Diagnosis>, IDiagnosisFeature
    {
        public DiagnosisRepo(PMContext db) : base(db) { }

        // crud in base repo class


        public List<Diagnosis> GetByPatient(int patientId)
        {
            var data = (from d in db.Diagnoses
                        where d.PatientID == patientId
                        select d).ToList();

            return data;
        }

        public List<Diagnosis> GetByDoctor(int doctorId)
        {
            var data = (from d in db.Diagnoses
                        where d.DoctorID == doctorId
                        select d).ToList();

            return data;
        }

        public List<Diagnosis> GetRecentDiagnoses(int days)
        {
            var fromDate = DateTime.Now.AddDays(-days);

            var data = (from d in db.Diagnoses
                        where d.DiagnosisDate >= fromDate
                        select d).ToList();

            return data;
        }
    }
}
