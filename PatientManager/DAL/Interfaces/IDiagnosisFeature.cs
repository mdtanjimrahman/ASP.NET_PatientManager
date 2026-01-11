using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IDiagnosisFeature
    {
        List<Diagnosis> GetByPatient(int patientId);
        List<Diagnosis> GetByDoctor(int doctorId);
        List<Diagnosis> GetRecentDiagnoses(int days);
    }
}
