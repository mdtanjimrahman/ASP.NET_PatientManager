using DAL.EF;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DataAccessFactory
    {
        PMContext db;

        public DataAccessFactory(PMContext db)
        {
            this.db = db;
        }

        // Generic repository access
        public IRepository<T> GetRepo<T>() where T : class
        {
            return new Repository<T>(db);
        }

        // Feature-specific repositories
        public IAppointmentFeature AppointmentFeature()
        {
            return new AppointmentRepo(db);
        }

        public IDiagnosisFeature DiagnosisFeature()
        {
            return new DiagnosisRepo(db);
        }

        public IDoctorFeature DoctorFeature()
        {
            return new DoctorRepo(db);
        }

        public IPatientFeature PatientFeature()
        {
            return new PatientRepo(db);
        }

        public IPrescriptionFeature PrescriptionFeature()
        {
            return new PrescriptionRepo(db);
        }

        public IMedicationFeature MedicationFeature()
        {
            return new MedicationRepo(db);
        }

        public ISummaryReport SummaryReport()
        {
            return new SummaryReportRepo(db);
        }
        public IPaymentFeature PaymentFeature()
        {
            return new PaymentRepo(db);
        }
        public IPatientReportFeature PatientReportFeature()
        {
            return new PatientReportRepo(db);
        }

    }
}
