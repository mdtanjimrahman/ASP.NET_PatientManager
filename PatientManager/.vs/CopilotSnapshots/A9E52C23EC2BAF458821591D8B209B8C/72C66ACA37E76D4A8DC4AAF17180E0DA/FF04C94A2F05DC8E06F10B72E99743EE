using BLL.DTOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class PatientReportService
    {
        DataAccessFactory factory;

        public PatientReportService(DataAccessFactory factory)
        {
            this.factory = factory;
        }

        public List<PatientDiagnosisDTO> GetPatientDiagnosisById(int patientId)
        {
            var data = factory.PatientReportFeature().GetPatientDiagnosisById(patientId);

            var ret = data.Select(d =>
            {
                dynamic temp = d;
                return new PatientDiagnosisDTO
                {
                    PatientName = temp.PatientName,
                    DiagnosisDetails = temp.DiagnosisDetails,
                    DiagnosisDate = temp.DiagnosisDate,
                    MedicationName = temp.MedicationName,
                    Dosage = temp.Dosage,
                    Duration = temp.Duration
                };
            }).ToList();

            return ret;
        }
    }
}
