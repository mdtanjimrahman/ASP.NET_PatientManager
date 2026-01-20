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
            var ret = data.Select(d => new PatientDiagnosisDTO
            {
                PatientName = d.PatientName,
                DiagnosisDetails = d.DiagnosisDetails,
                DiagnosisDate = d.DiagnosisDate,
                MedicationName = d.MedicationName,
                Dosage = d.Dosage,
                Duration = d.Duration
            }).ToList();
            return ret;
        }
    }
}
