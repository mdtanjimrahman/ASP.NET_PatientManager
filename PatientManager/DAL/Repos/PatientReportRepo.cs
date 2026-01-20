using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    internal class PatientReportRepo : IPatientReportFeature
    {
        PMContext db;

        public PatientReportRepo(PMContext db)
        {
            this.db = db;
        }

        // Internal helper class
        private class TempPatientDiagnosis
        {
            public string PatientName { get; set; }
            public string DiagnosisDetails { get; set; }
            public string DiagnosisDate { get; set; }
            public string MedicationName { get; set; }
            public string Dosage { get; set; }
            public string Duration { get; set; }
        }

        public List<object> GetPatientDiagnosisById(int patientId)
        {
            var data = from p in db.Patients
                       join d in db.Diagnoses on p.PatientID equals d.PatientID
                       join pr in db.Prescriptions on p.PatientID equals pr.PatientID into prList
                       from pr in prList.DefaultIfEmpty()
                       join m in db.Medications on pr.PrescriptionID equals m.PrescriptionID into meds
                       from med in meds.DefaultIfEmpty()
                       where p.PatientID == patientId
                       select new TempPatientDiagnosis
                       {
                           PatientName = p.FirstName + " " + p.LastName,
                           DiagnosisDetails = d.DiagnosisDetails,
                           DiagnosisDate = d.DiagnosisDate.ToString("yyyy-MM-dd"),
                           MedicationName = med != null ? med.MedicationName : "-",
                           Dosage = med != null ? med.Dosage : "-",
                           Duration = med != null ? med.Duration : "-"
                       };

            return data.Cast<object>().ToList();
        }
    }
}
